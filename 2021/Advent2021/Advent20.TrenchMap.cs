using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using Advent2021.Models;

namespace Advent2021
{
    public static class TrenchMap
    {
        private static string GetPaddedRow(int length, char paddingChar)
        {
            return "".PadLeft(length, paddingChar);
        }
        
        public static List<string> Expand(List<string> image, bool isOnePadding)
        {
            var imageWidth = image[2].Length + 4;
            var paddingChar = isOnePadding ? '1' : '0';
            
            var expandedImage = new List<string>();
            expandedImage.Add(GetPaddedRow(imageWidth, paddingChar));
            expandedImage.Add(GetPaddedRow(imageWidth, paddingChar));
            for(var i = 0; i < image.Count; i++)
            {
                expandedImage.Add($"{paddingChar}{paddingChar}" + image[i] + $"{paddingChar}{paddingChar}");
            }
            expandedImage.Add(GetPaddedRow(imageWidth, paddingChar));
            expandedImage.Add(GetPaddedRow(imageWidth, paddingChar));
            return expandedImage;
        }

        public static IEnumerable<string> Enhance(Dictionary<string, char> enhancementSet, List<string> image)
        {
            var outputImage = new List<string>();
            for (var i = 0; i < image.Count - 2; i++)
            {
                var outputRow = "";
                for (var j = 0; j < image[0].Count() - 2; j++)
                {
                    var row1 = image[i].Substring(j, 3);
                    var row2 = image[i+1].Substring(j, 3);
                    var row3 = image[i+2].Substring(j, 3);

                    var binCheck = row1 + row2 + row3;
                    outputRow += enhancementSet[binCheck];
                }
                outputImage.Add(outputRow);
            }

            return outputImage;
        }
    }
}