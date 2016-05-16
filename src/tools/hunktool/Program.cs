﻿using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Reko.ImageLoaders.Hunk;
using DocoptNet;
using System.Globalization;
using System.IO;
using Reko.Core;

namespace hunktool
{
    public class Program
    {
        private const string options = @"hunktool - AmigaOS Hunk file browser

Usage:
    hunktool [options] [<command>] <files>

Options:
    -d, --dump                         Dump the hunk structure
    -v, --verbose                      Be more verbos
    -s, --stop                         Stop on error
    -R, --show-relocs                  Show relocation entries
    -D, --show-debug                   Show debug info entries
    -A, --disassemble                  Disassemble code segments
    -S, --disassemble-start [address]  action = store, type = @int, @default = 0, help = start address for dissassembly
    -x, --hexdump                      action store_true, @default = false, help = dump segments in hex
    -b, --brief                        action store_true, @default = false, help = show only brief information
    -B, --base-address [address]       action = store, type = @int, @default = 0, help = base address for relocation
    -o, --use-objdump                  action = store_true, @default = false, help = disassemble with m68k-elf-objdump instead of vda68k
    -c, --cpu [cpuType=68000]          action = store,  help = disassemble for given cpu (objdump only)
";

        // ----- commands -------------------------------------------------------------
        public abstract class HunkCommand
        {
            private Dictionary<object, int> counts;
            public IDictionary<string, ValueObject> args;
            private List<string> failed_files;

            public HunkCommand(IDictionary<string, ValueObject> args)
            {
                this.counts = new Dictionary<object, int>
                {
                };
                this.args = args;
                this.failed_files = new List<string>();
            }

            public object handle_file(string path, HunkFile hunk_file)
            {
                bool ok = true;
                Console.WriteLine(path);
            
                    // if verbose then print block structure
                if (this.args["verbose"].IsTrue)
                {
                    Console.WriteLine();
                    //Console.WriteLine("  hunks:    ", hunk_file.get_hunk_summary());
                    if (args["dump"].IsTrue)
                    {
                        //print_pretty(hunk_file.hunks);
                    }
                    Console.WriteLine("  type:     ");
                    // build segments from hunks
                }
                Console.WriteLine(hunk_file.type.ToString());
                // if verbose then print hunk structure
                if (this.args["verbose"].IsTrue)
                {
                    //Console.WriteLine();
                    //Console.WriteLine("  segments: ", hunk_file.get_segment_summary());
                    //Console.WriteLine("  overlays: ", hunk_file.get_overlay_segment_summary());
                    //Console.WriteLine("  libs:     ", hunk_file.get_libs_summary());
                    //Console.WriteLine("  units:    ", hunk_file.get_units_summary());
                    //if (args.dump)
                    //{
                    //    print_pretty(hunk_file.hunks);
                    //}
                }
                else
                {
                    Console.WriteLine();
                    // do special processing on hunk file for command
                }
                ok = this.handle_hunk_file(path, hunk_file);
                return ok;
            }

            public abstract bool handle_hunk_file(string s, HunkFile hunk_file);

            public virtual int result()
            {
                return 0;
            }

            public virtual object process_file(string scan_file)
            {
                object delta;
                object end;
                object fobj;
                object path;
                object result;
                object start;
                //path = scan_file.get_path();
                //fobj = scan_file.get_fobj();
                var hunkBytes = File.ReadAllBytes(scan_file);
                var loader = new HunkLoader(null, scan_file, hunkBytes);
                Address addr;
                if (!Address.TryParse32((string) args["base-address"].Value, out addr))
                    addr = Address.Ptr32(0);
                result = loader.Load(addr);
                // ignore non hunk files
                return this.handle_file(scan_file, loader.HunkFile);
            }

            public virtual object run()
            {
                // setup error handler
                //scanners = new List<object> {
                //    ADFSScanner(),
                //    ZipScanner(),
                //    LhaScanner()
                //};
                foreach (string file in args["files"].AsList)
                {
                    this.process_file(file);
                }
                //scanner = new FileScanner(this.process_file, error_handler: error_handler, scanners: scanners);
                //foreach (var path in this.args.files)
                //{
                //    ok = scanner.scan(path);
                //    if (!ok)
                //    {
                //        Console.WriteLine("ABORTED");
                //        return false;
                //    }
                //}
                return true;
            }

                // ----- Validator -----
            //public static object error_handler(object sf, object e)
            //{
            //    Console.WriteLine("FAILED", sf.get_path(), e);
            //    return args["stop"].IsFalse;
            //    // setup scanners
            //}
        }

        public class Validator
            : HunkCommand
        {
            public Validator(IDictionary<string, ValueObject> args) : base(args) { }

            public override bool handle_hunk_file(string path, HunkFile hunk_file)
            {
                // do nothing extra
                return true;
                // ----- Info -----
            }
        }

        public class Info
            : HunkCommand
        {
            public Info(IDictionary<string, ValueObject> args)
                : base(args)
            {

            }
            public override bool handle_hunk_file(string path, HunkFile hunk_file)
            {
                // verbose all hunk
                var hs = new HunkShow(
                    hunk_file,
                    show_relocs: args["show-relocs"].IsTrue,
                    show_debug: args["show-debug"].IsTrue,
                    disassemble: args["disassemble"].IsTrue,
                    disassemble_start: UInt32.Parse(
                        (string)args["disassemble-start"].Value,
                        NumberStyles.HexNumber,
                        CultureInfo.InvariantCulture),
                    use_objdump: args["use-objdump"].IsTrue,
                    cpu: (string)args["cpu"].Value,
                    hexdump: args["hexdump"].IsTrue,
                    brief: args["brief"].IsTrue);
                hs.show_segments();
                return true;
            }
        }

        // ----- Relocate -----
        public class Relocate
            : HunkCommand
        {
            public Relocate(IDictionary<string, ValueObject> args)
                : base(args)
            {

            }
            public override bool handle_hunk_file(string path, HunkFile hunk_file)
            {
                //    object base_addr;
                //    object datas;
                //    object rel;
                //    if (hunk_file.type != FileType.TYPE_LOADSEG)
                //    {
                //        Console.WriteLine("ERROR: can only relocate LoadSeg()able files:", path);
                //        return false;
                //    }
                //    var rel = new HunkRelocate(hunk_file, verbose = this.args.verbose);
                //    // get sizes of all segments
                //    var sizes = rel.get_sizes();
                //    // calc begin addrs for all segments
                //    base_addr = this.args.base_address;
                //    IEnumerable<uint> addrs = rel.get_seq_addrs(base_addr);
                //    // relocate and return data of segments
                //    datas = rel.relocate(addrs);
                //    if (datas == null)
                //    {
                //        Console.WriteLine("ERROR: relocation failed:", path);
                //        return false;
                //    }
                //    else
                //    {
                //        Console.WriteLine("Relocate to base address", base_addr);
                //        Console.WriteLine("Bases: ", string.Join(" ", addrs.Select(x => String.Format("%06x", x), addrs)));
                //        Console.WriteLine("Sizes: ", string.Join(" ", sizes.Select(x => String.Format("%06x", x), sizes)));
                //        Console.WriteLine("Data:  ", string.Join(" ", (map(x => String.Format("%06x", len(x)), datas)));
                //        Console.WriteLine("Total: ", String.Format("%06x", rel.get_total_size()));
                //        if (args["hexdump"].IsTrue)
                //        {
                //            foreach (var d in datas)
                //            {
                //                print_hex(d);
                //            }
                //        }
                //        return true;
                //    }
                //}
                return true;
            }

            // ----- Elf2Hunk -----
            public class ElfInfo
            {
                private IDictionary<string, ValueObject> args;

                public ElfInfo(IDictionary<string, ValueObject> args)
                {
                    this.args = args;
                }

                public virtual int run()
                {
                    //object dumper;
                    //object elf;
                    //object reader;
                    //foreach (var f in args.files)
                    //{
                    //    reader = amitools.binfmt.elf.ELFReader();
                    //    elf = reader.load(open(f, "rb"));
                    //    if (elf == null)
                    //    {
                    //        Console.WriteLine("ERROR loading ELF:", elf.error_string);
                    //        return 1;
                    //    }
                    //    dumper = amitools.binfmt.elf.ELFDumper(elf);
                    //    dumper.dump_sections(show_relocs = args.show_relocs, show_debug = args.show_debug);
                    //    dumper.dump_symbols();
                    //    dumper.dump_relas();
                    //}
                    return 0;
                    // ----- main -----
                }
            }


            public static object main(string[] args)
            {
                Type cmd_cls;
                Dictionary<string,
                    Type> cmd_map;
                object res;
                // call scanner and process all files with selected command
                cmd_map = new Dictionary<string, Type> {
            {
                "validate",
                typeof(Validator)},
            {
                "info",
                typeof(Info)},
            {
                "elfinfo",
                typeof(ElfInfo)},
            {
                "relocate",
                typeof(Relocate)}};
                var docopt = new Docopt();
                var options = docopt.Apply(Program.options, args);
                var cmd = options["command"].Value.ToString();
                if (!cmd_map.ContainsKey(cmd))
                {
                    Console.WriteLine("INVALID COMMAND:", cmd);
                    Console.WriteLine("valid commands are:");
                    foreach (var a in cmd_map)
                    {
                        Console.WriteLine("  ", a);
                    }
                    return 1;
                }
                cmd_cls = cmd_map[cmd];
                // execute command
                var cmdInst = (HunkCommand)Activator.CreateInstance(cmd_cls, options);
                res = cmdInst.run();
                return res;
            }

        }
    }
}
