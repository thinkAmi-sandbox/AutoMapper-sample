using System;
using System.Collections;
using System.Collections.Generic;
using MyApp.ArrayListToObject;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RunArrayListToObjectSample();
        }

        public static void RunArrayListToObjectSample()
        {
            // ArrayListをFruitにマップ
            ArrayListToObjectSample.ToObjects();
            
            // List<ArrayList>を、List<Fruit>にマップ
            ArrayListToObjectSample.ToListObjects();
            
            // 逆方向
            ArrayListToObjectSample.ToArrayListByReverseMap();
            
            // Profileを使ったマップ
            ArrayListToObjectSample.MapByProfile();
        }
    }
}
