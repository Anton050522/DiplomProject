using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace EnumExt
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
        public static SelectList GetSelectList(this Enum @enum)
        {
            Array values = Enum.GetValues(@enum.GetType());
            List<SelectListItem> items = new List<SelectListItem>(values.Length);
            string[] descriptions = new string[values.Length];
            int index = 0;
            foreach (Enum e in Enum.GetValues(@enum.GetType()))
            {
                descriptions[index] = e.GetEnumDescription();
                index++;
            }
            index = 0;
            foreach (var i in values)
            {
                items.Add(new SelectListItem
                {
                    Text = descriptions[index],
                    Value = i.ToString()
                });
                index++;
            }
            return new SelectList(items, "Value", "Text");
        }
    }
}