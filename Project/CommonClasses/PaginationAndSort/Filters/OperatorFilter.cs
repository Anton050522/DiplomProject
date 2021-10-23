using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.Filters
{
    public class OperatorFilter
    {
        public OperatorFilter(List<Operator> operators, int? @operator, string operatorName)
        {
            operators.Insert(0, new Operator { FirstName = "Все", OperatorId = 0 });
            Operators = new SelectList(operators, "OperatorId", "FirstName", @operator);
            SelectedOperator = @operator;
            SelectedName = operatorName;
        }

        public SelectList Operators { get; private set; }
        public int? SelectedOperator { get; private set; }
        public string SelectedName { get; private set; }
    }
}
