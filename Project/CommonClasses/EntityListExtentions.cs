using EnumExt;
using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System.Collections.Generic;
using System.Windows.Controls.Primitives;

namespace Common.ListExtentions
{
    public static class EntityListExtentions
    {
        public static SelectList GetOrganisationSelectList(this List<Organisation> list)
        {
            List<SelectListItem> items = new List<SelectListItem>(list.Count);
            foreach (var li in list)
            {
                items.Add(new SelectListItem
                {
                    Text = li.OrgName,
                    Value = li.OrganisationId.ToString()
                });
            }
            items.Add(new SelectListItem("-----", ""));
            foreach (var item in items)
            {
                if (item.Text == "-----")
                {
                    item.Selected = true;
                }
            }
            return new SelectList(items, "Value", "Text");
        }

        public static SelectList GetGlobalSectionSelectList(this List<GlobalSection> list)
        {
            List<SelectListItem> items = new List<SelectListItem>(list.Count);
            foreach (var li in list)
            {
                items.Add(new SelectListItem
                {
                    Text = li.GlobalSectionName,
                    Value = li.GlobalSectId.ToString()
                });
            }
            items.Add(new SelectListItem("-----", ""));
            foreach (var item in items)
            {
                if (item.Text == "-----")
                {
                    item.Selected = true;
                }
            }
            return new SelectList(items, "Value", "Text");
        }

        public static SelectList GetLocalSectionSelectList(this List<LocalSection> list)
        {
            List<SelectListItem> items = new List<SelectListItem>(list.Count);
            foreach (var li in list)
            {
                items.Add(new SelectListItem
                {
                    Text = li.LocalSectionName,
                    Value = li.LocalSectionId.ToString()
                });
            }
            items.Add(new SelectListItem("-----", ""));
            foreach (var item in items)
            {
                if (item.Text == "-----")
                {
                    item.Selected = true;
                }
            }
            return new SelectList(items, "Value", "Text");
        }

        public static SelectList GetDefectSelectList(this List<Defect> list)
        {
            List<SelectListItem> items = new List<SelectListItem>(list.Count);
            foreach (var li in list)
            {
                items.Add(new SelectListItem
                {
                    Text = li.DefectCode.GetEnumDescription(),
                    Value = li.DefectId.ToString()
                });
            }
            items.Add(new SelectListItem("-----", ""));
            foreach (var item in items)
            {
                if (item.Text == "-----")
                {
                    item.Selected = true;
                }
            }
            return new SelectList(items, "Value", "Text");
        }

        public static SelectList GetDangerousDefectSelectList(this List<DangerousDefect> list)
        {
            List<SelectListItem> items = new List<SelectListItem>(list.Count);
            foreach (var li in list)
            {
                items.Add(new SelectListItem
                {
                    Text = li.DangerousDefectCode.GetEnumDescription(),
                    Value = li.DangerousDefectId.ToString()
                });
            }
            items.Add(new SelectListItem("-----", ""));
            foreach (var item in items)
            {
                if (item.Text == "-----")
                {
                    item.Selected = true;
                }
            }
            return new SelectList(items, "Value", "Text");
        }

        public static SelectList GetDefectoscopeSelectList(this List<Defectoscope> list)
        {
            List<SelectListItem> items = new List<SelectListItem>(list.Count);
            foreach (var li in list)
            {
                items.Add(new SelectListItem
                {
                    Text = li.DefectoScopeType.GetEnumDescription(),
                    Value = li.DefectoScopeId.ToString()
                });
            }
            foreach (var item in items)
            {
                if (item.Text == "-----")
                {
                    item.Selected = true;
                }
            }
            return new SelectList(items, "Value", "Text");
        }

        public static SelectList GetOperatorSelectList(this List<Operator> list)
        {
            List<SelectListItem> items = new List<SelectListItem>(list.Count);
            foreach (var li in list)
            {
                items.Add(new SelectListItem
                {
                    Text = li.LastName,
                    Value = li.OperatorId.ToString()
                });
            }
            foreach (var item in items)
            {
                if (item.Text == "-----")
                {
                    item.Selected = true;
                }
            }
            return new SelectList(items, "Value", "Text");
        }
    }
}