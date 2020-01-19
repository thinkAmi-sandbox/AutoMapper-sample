using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;

namespace MyApp.ArrayListToObject
{
    public class ArrayListToObjectSample
    {
        public static void ToObjects()
        {
            var config = new MapperConfiguration(c => 
                c.CreateMap<ArrayList, Fruit>()
                    .ForMember(d => d.Id, o => o.MapFrom(s => s[0]))
                    .ForMember(d => d.Name, o => o.MapFrom(s => s[1]))
                    .ForMember(d => d.Season, o => o.MapFrom(s => s[2]))
                    .ForMember(d => d.UnitPrice, o => o.MapFrom(s => s[3]))
                );
            var mapper = config.CreateMapper();
            
            var source = new ArrayList {"1", "すいか", "夏", 1000};
            var dest = mapper.Map<Fruit>(source);
            
            Console.WriteLine("ArrayList to Fruit");
            Console.WriteLine(
                $"ID: {dest.Id}, Name: {dest.Name}, Season: {dest.Season}, UnitPrice: {dest.UnitPrice}");
            
        }
        
        public static void ToListObjects()
        {
            // AutoMapperでマッピング
            var config = new MapperConfiguration(c => 
                c.CreateMap<ArrayList, Fruit>()
                    .ForMember(d => d.Id, o => o.MapFrom(s => s[0]))
                    .ForMember(d => d.Name, o => o.MapFrom(s => s[1]))
                    .ForMember(d => d.Season, o => o.MapFrom(s => s[2]))
                    .ForMember(d => d.UnitPrice, o => o.MapFrom(s => s[3]))
            );
            var mapper = config.CreateMapper();
            
            var source = new List<ArrayList>
            {
                new ArrayList {"1", "すいか", "夏", 1000},
                new ArrayList {"2", "りんご", "秋", 100},
                new ArrayList {"3", "みかん", "冬", 150}
            };
            
            // http://docs.automapper.org/en/stable/Lists-and-arrays.html#lists-and-arrays
            var dest = mapper.Map<List<ArrayList>, List<Fruit>>(source);

            Console.WriteLine("List<ArrayList> to List<Fruit>");
            foreach (var fruit in dest)
            {
                Console.WriteLine(
                    $"ID: {fruit.Id}, Name: {fruit.Name}, Season: {fruit.Season}, UnitPrice: {fruit.UnitPrice}");
            }
        }

        public static void ToArrayListByReverseMap()
        {
            // http://docs.automapper.org/en/stable/Reverse-Mapping-and-Unflattening.html
            // https://stackoverflow.com/questions/6179903/automapper-concrete-object-to-array
            
            // AutoMapperでマッピング
            var config = new MapperConfiguration(c => 
                c.CreateMap<ArrayList, Fruit>()
                    .ForMember(d => d.Id, o => o.MapFrom(s => s[0]))
                    .ForMember(d => d.Name, o => o.MapFrom(s => s[1]))
                    .ForMember(d => d.Season, o => o.MapFrom(s => s[2]))
                    .ForMember(d => d.UnitPrice, o => o.MapFrom(s => s[3]))
                    
                    // 逆マップ
                    .ReverseMap()
                    .ConstructUsing(x => new ArrayList
                    {
                        x.Id, x.Name, x.Season, x.UnitPrice
                    })
            );
            var mapper = config.CreateMapper();
            
            Console.WriteLine("正方向");
            var source = new ArrayList {"1", "すいか", "夏", 1000};
            var dest = mapper.Map<Fruit>(source);
            
            Console.WriteLine(
                $"ID: {dest.Id}, Name: {dest.Name}, Season: {dest.Season}, UnitPrice: {dest.UnitPrice}");
            
            
            var sourceList = new List<ArrayList>
            {
                new ArrayList {"1", "すいか", "夏", 1000},
                new ArrayList {"2", "りんご", "秋", 100},
                new ArrayList {"3", "みかん", "冬", 150}
            };
            var destList = mapper.Map<List<ArrayList>, List<Fruit>>(sourceList);

            Console.WriteLine("正方向List");
            foreach (var fruit in destList)
            {
                Console.WriteLine(
                    $"ID: {fruit.Id}, Name: {fruit.Name}, Season: {fruit.Season}, UnitPrice: {fruit.UnitPrice}");
            }
            
            
            Console.WriteLine("逆方向");
            
            var reverseSource = new Fruit {Id = 1, Name = "すいか", Season = "夏", UnitPrice = 1000};
            var reverseDst = mapper.Map<ArrayList>(reverseSource);
            
            Console.WriteLine(
                $"ID: {reverseDst[0]}, Name: {reverseDst[1]}, Season: {reverseDst[2]}, UnitPrice: {reverseDst[3]}");
            
            
            Console.WriteLine("逆方向List");
            
            var reverseSourceList = new List<Fruit>
            {
                new Fruit {Id = 1, Name = "すいか", Season = "夏", UnitPrice = 1000},
                new Fruit {Id = 2, Name = "りんご", Season = "秋", UnitPrice = 100},
                new Fruit {Id = 3, Name = "みかん", Season = "冬", UnitPrice = 150}
            
            };
            var reverseDestList = mapper.Map<List<Fruit>, List<ArrayList>>(reverseSourceList);

            foreach (var dst in reverseDestList)
            {
                Console.WriteLine(
                    $"ID: {dst[0]}, Name: {dst[1]}, Season: {dst[2]}, UnitPrice: {dst[3]}");
            }
        }

        public static void MapByProfile()
        {
            // http://docs.automapper.org/en/stable/Configuration.html
            var config = new MapperConfiguration(c => 
                c.AddMaps(new []
                {
                    "MyApp",
                })
            );
            var mapper = config.CreateMapper();
            
            Console.WriteLine("正方向 (Profile使用)");
            var source = new ArrayList {"1", "すいか", "夏", 1000};
            var dest = mapper.Map<Fruit>(source);
            
            Console.WriteLine(
                $"ID: {dest.Id}, Name: {dest.Name}, Season: {dest.Season}, UnitPrice: {dest.UnitPrice}");
            
            
            var sourceList = new List<ArrayList>
            {
                new ArrayList {"1", "すいか", "夏", 1000},
                new ArrayList {"2", "りんご", "秋", 100},
                new ArrayList {"3", "みかん", "冬", 150}
            };
            var destList = mapper.Map<List<ArrayList>, List<Fruit>>(sourceList);

            Console.WriteLine("正方向List (Profile使用)");
            foreach (var fruit in destList)
            {
                Console.WriteLine(
                    $"ID: {fruit.Id}, Name: {fruit.Name}, Season: {fruit.Season}, UnitPrice: {fruit.UnitPrice}");
            }
            
            
            Console.WriteLine("逆方向 (Profile使用)");
            
            var reverseSource = new Fruit {Id = 1, Name = "すいか", Season = "夏", UnitPrice = 1000};
            var reverseDst = mapper.Map<ArrayList>(reverseSource);
            
            Console.WriteLine(
                $"ID: {reverseDst[0]}, Name: {reverseDst[1]}, Season: {reverseDst[2]}, UnitPrice: {reverseDst[3]}");
            
            
            Console.WriteLine("逆方向List (Profile使用)");
            
            var reverseSourceList = new List<Fruit>
            {
                new Fruit {Id = 1, Name = "すいか", Season = "夏", UnitPrice = 1000},
                new Fruit {Id = 2, Name = "りんご", Season = "秋", UnitPrice = 100},
                new Fruit {Id = 3, Name = "みかん", Season = "冬", UnitPrice = 150}
            
            };
            var reverseDestList = mapper.Map<List<Fruit>, List<ArrayList>>(reverseSourceList);

            foreach (var dst in reverseDestList)
            {
                Console.WriteLine(
                    $"ID: {dst[0]}, Name: {dst[1]}, Season: {dst[2]}, UnitPrice: {dst[3]}");
            }
        }
    }


    public class Fruit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Season { get; set; }
        public decimal UnitPrice { get; set; }
    }
}