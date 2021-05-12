using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using Bunit;
using Microsoft.AspNetCore.Components;

namespace DOS_TEST
{
    internal static class CommonTestFunctions
    {

        internal static IElement GetSubmitButton<T>(this IRenderedComponent<T> cut) where T : IComponent
            => cut.Find("button[type='submit']");

        internal static IElement GetForm<T>(this IRenderedComponent<T> cut) where T : IComponent
            => cut.Find("form");

        internal static IElement GetValidationErrors<T>(this IRenderedComponent<T> cut) where T : IComponent
            => cut.Find("ul.validation-errors");

        internal static IElement GetTextBox<T>(this IRenderedComponent<T> cut, string name) where T : IComponent
            => cut.FindAll("input").First(x => x.PreviousElementSibling?.TextContent == name);

        internal static IElement GetDropDownList<T>(this IRenderedComponent<T> cut, string name) where T : IComponent
            => cut.FindAll("input").First(x => x.ParentElement?.ParentElement?.FirstElementChild?.TextContent == name);

        internal static IElement GetListViewItem<T>(this IRenderedComponent<T> cut, int id) where T : IComponent
            => cut.Find($"li.e-list-item[data-uid={id}]");

        internal static IElement GetNumericTextBox<T>(this IRenderedComponent<T> cut, string name) where T : IComponent
            => cut.FindAll("input.e-numerictextbox").First(x => x.ParentElement?.ParentElement?.FirstElementChild?.TextContent == name);

        internal static void Shuffle<T>(this IList<T> list)
        {
            Random random = new Random();
            int n = list.Count;

            for (int i = list.Count - 1; i > 1; i--)
            {
                int rnd = random.Next(i + 1);

                T value = list[rnd];
                list[rnd] = list[i];
                list[i] = value;
            }
        }

        internal static string RandomString(int length)
        {
            Random random = new Random();

            const string chars = ".,-+@#:!?=\'\"|\\><^&()*%$`~abcdefghijklmnopqrstuvxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        internal static decimal RandomDecimal(decimal min, decimal max)
        {
            Random random = new Random();

            return (decimal)random.NextDouble() * (max - min) + min;
        }

        internal static int RandomInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max + 1);
        }
    }
}
