using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DeepClient.Client.Misc
{
    public class Resources
    {
        public static Sprite LoadSprite(string sprite)
        {
            return (resourcePath + "/" + sprite).LoadSpriteFromDisk();
        }
        private static string resourcePath = Path.Combine(Environment.CurrentDirectory, "DeepClient/");
    }
}