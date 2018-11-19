﻿using System;
using System.Collections.Generic;

namespace Ann.Utils
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            var i = 0;
            foreach (var e in source) action(e, i++);
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T element in source)
                action(element);
        }

        public static void ForEach<T>(this T[,] source, Action<T> action)
        {
            for (int w = 0; w < source.GetLength(0); w++)
            {
                for (int h = 0; h < source.GetLength(1); h++)
                {
                    action(source[w, h]);
                }
            }
        }

        public static void ForEach<T>(this T[,] source, Action<T, int, int> action)
        {
            for (int w = 0; w < source.GetLength(0); w++)
            {
                for (int h = 0; h < source.GetLength(1); h++)
                {
                    action(source[w, h], w, h);
                }
            }
        }

        public static void ForEach<T>(this T[,] source, Action<int, int> action)
        {
            for (int w = 0; w < source.GetLength(0); w++)
            {
                for (int h = 0; h < source.GetLength(1); h++)
                {
                    action(w, h);
                }
            }
        }

        public static T[,] GetChannel<T>(this T[,,] source, int channel)
        {
            var output = new T[source.GetLength(1), source.GetLength(2)];

            for (int i = 0; i < source.GetLength(1); i++)
            {
                for (int j = 0; j < source.GetLength(2); j++)
                {
                    output[i, j] = source[channel, i, j];
                }
            }

            return output;
        }

        public static void SetChannel<T>(this T[,,] source, T[,] values, int channel)
        {
            if(source.GetLength(1) != values.GetLength(0) ||
                source.GetLength(2) != values.GetLength(1))
            {
                throw new Exception("Can not set values for channel. Dimensions do not match.");
            }
            else if(channel < 0)
            {
                throw new Exception("Can not set values for channel. Channel number must greater or equal to 0.");
            }
            else if(source.GetLength(0) < channel)
            {
                throw new Exception($"Can not set values for channel. Volume do not have channel {channel}");
            }

            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    source[channel, i, j] = values[i, j];
                }
            }
        }

        public static void ForEach<T>(this T[,,] source, Action<T, int, int, int> action)
        {
            for (int w = 0; w < source.GetLength(0); w++)
            {
                for (int h = 0; h < source.GetLength(1); h++)
                {
                    for (int d = 0; d < source.GetLength(2); d++)
                    {
                        action(source[w, h, d], w, h, d);
                    }
                }
            }
        }

        public static void ForEach<T>(this T[,,] source, Action<int, int, int> action)
        {
            for (int w = 0; w < source.GetLength(0); w++)
            {
                for (int h = 0; h < source.GetLength(1); h++)
                {
                    for (int d = 0; d < source.GetLength(2); d++)
                    {
                        action(w, h, d);
                    }
                }
            }
        }

        public static void ForEach<T>(this T[,,] source, Action<T> action)
        {
            for (int w = 0; w < source.GetLength(0); w++)
            {
                for (int h = 0; h < source.GetLength(1); h++)
                {
                    for (int d = 0; d < source.GetLength(2); d++)
                    {
                        action(source[w, h, d]);
                    }
                }
            }
        }

        public static void ForEach<T>(this T[,,,] source, Action<int, int, int, int> action)
        {
            for (int k = 0; k < source.GetLength(0); k++)
            {
                for (int d = 0; d < source.GetLength(1); d++)
                {
                    for (int h = 0; h < source.GetLength(2); h++)
                    {
                        for (int w = 0; w < source.GetLength(3); w++)
                        {
                            action(k,d,h,w);
                        }
                    }
                }
            }
        }

        public static void ForEach<T>(this T[,,,] source, Action<T,int, int, int, int> action)
        {
            for (int k = 0; k < source.GetLength(0); k++)
            {
                for (int d = 0; d < source.GetLength(1); d++)
                {
                    for (int h = 0; h < source.GetLength(2); h++)
                    {
                        for (int w = 0; w < source.GetLength(3); w++)
                        {
                            action(source[k, d, h, w], k, d, h, w);
                        }
                    }
                }
            }
        }
    }
}
