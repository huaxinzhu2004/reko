﻿#region License
/* 
 * Copyright (C) 1999-2018 John Källén.
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2, or (at your option)
 * any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; see the file COPYING.  If not, write to
 * the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA.
 */
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Reko.Gui.Windows.Controls
{
    public class StyleStack : IDisposable
    {
        private IUiPreferencesService uiPrefSvc;
        private List<string[]> stack;
        private SolidBrush fg;
        private SolidBrush bg;
        private Font font;

        public StyleStack(IUiPreferencesService uiPrefSvc)
        {
            if (uiPrefSvc == null) throw new ArgumentNullException("uiPrefSvc");
            this.uiPrefSvc = uiPrefSvc;
            this.stack = new List<string[]>();
        }

        public void Dispose()
        {
            if (font != null)
                font.Dispose();
            font = null;
            if (bg != null)
                bg.Dispose();
            bg = null;
            if (fg != null)
                fg.Dispose();
            fg = null;
        }

        public void PushStyle(string styleSelector)
        {
            if (styleSelector == null)
                stack.Add(new string[0]);
            else
                stack.Add(styleSelector.Split(' '));
        }

        internal void PopStyle()
        {
            stack.RemoveAt(stack.Count - 1);
        }

        private SolidBrush CacheBrush(ref SolidBrush brInstance, SolidBrush brNew)
        {
            if (brInstance != null)
                brInstance.Dispose();
            brInstance = brNew;
            return brNew;
        }

        private IEnumerable<UiStyle> GetStyles(string[] styles)
        {
            foreach (var styleName in styles)
            {
                UiStyle style;
                if (uiPrefSvc.Styles.TryGetValue(styleName, out style))
                    yield return style;
            }
        }

        public SolidBrush GetForeground(Control ctrl)
        {
            for (int i = stack.Count - 1; i >= 0; --i)
            {
                var styles = GetStyles(stack[i]);
                var ff = styles.Select(s => s.Foreground).LastOrDefault(f => f != null);
                if (ff != null)
                    return ff;
            }
            return CacheBrush(ref fg, new SolidBrush(ctrl.ForeColor));
        }

        public Cursor GetCursor(Control ctrl)
        {
            Cursor cu;
            for (int i = stack.Count - 1; i>=0; --i)
            {
                var styles = GetStyles(stack[i]);
                cu = styles.Select(s => s.Cursor).LastOrDefault(c => c != null);
                if (cu != null)
                    return cu;
            }
            return Cursors.Default;
        }

        public Color GetForegroundColor(Color fgColor)
        {
           for(int i = stack.Count - 1; i >= 0; --i)
            {
                var styles = GetStyles(stack[i]);
                var fg = styles.Select(s => s.Foreground).LastOrDefault(f => f != null);
                if (fg != null)
                    return fg.Color;
            }
            return fgColor;
        }

        public SolidBrush GetBackground(Color bgColor)
        {
            for (int i = stack.Count - 1; i >= 0; --i)
            {
                var styles = GetStyles(stack[i]);
                var back = styles.Select(s => s.Background).LastOrDefault(b => b != null);
                if (back != null)
                    return back;
            }
            return CacheBrush(ref bg, new SolidBrush(bgColor));
        }

        public Font GetFont(Font defaultFont)
        {
            for (int i = stack.Count - 1; i >= 0; --i)
            {
                var styles = GetStyles(stack[i]);
                var font = styles.Select(s => s.Font).LastOrDefault(f => f != null);
                if (font != null)
                    return font;
            }
            return defaultFont;
        }

        public int? GetWidth()
        {
            for (int i = stack.Count - 1; i >= 0; --i)
            {
                var styles = GetStyles(stack[i]);
                var width = styles.Select(s => s.Width).LastOrDefault(w => w.HasValue);
                if (width.HasValue)
                    return width;
            }
            return null;
        }

        public float GetNumber(Func<UiStyle, float> fn)
        {
            for (int i = stack.Count - 1; i >= 0; --i)
            {
                var styles = GetStyles(stack[i]);
                var value = styles.Select(fn).LastOrDefault(n => n != 0);
                if (value != 0)
                    return value;
            }
            return 0;
        }

        /// <summary>
        /// Given a rectangle <paramref name="rc"/>, creates a padded rectangle
        /// <paramref name="rcPadded"/> and 
        /// </summary>
        /// <param name="rc"></param>
        /// <param name="rcPadded"></param>
        public void PadRectangle(ref RectangleF rc, ref RectangleF rcPadded)
        {
            float top = GetNumber(s => s.PaddingTop);
            float left = GetNumber(s => s.PaddingLeft);
            float bottom = GetNumber(s => s.PaddingBottom);
            float right = GetNumber(s => s.PaddingRight);
            rcPadded.X = rc.X;
            rcPadded.Width = rc.Width + left + right;
            rcPadded.Y = rc.Y;
            rcPadded.Height = rc.Height + top + bottom;

            rc.Offset(left, top);
        }
    }
}