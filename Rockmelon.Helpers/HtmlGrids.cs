using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.Mvc;


namespace Rockmelon.Helpers
{
    public class GridItems<T>
    {
        public IList<T> Items { get; set; }
        public IEnumerable<Func<T, object>> Columns { get; set; }
        public Func<T, int> PrimaryKey { get; set; }
        public GridItems()
        {
            Items = new List<T>();
            Columns = new List<Func<T, object>>();
        }
        
    }
    public static class HtmlGrids
    {
        public static string Grid<T>(this HtmlHelper htmlHelper, string id, GridItems<T> Items)
        {
            var sb = new StringBuilder();
            sb.Append(String.Format("<table id='{0}' class='tablesorter'>", id));
            sb.Append("<thead>");
            sb.Append("<tr><th>Click a header to sort</th></tr>");
            sb.Append("<tr>");
            foreach (var columns in Items.Columns)
            {
                sb.Append(String.Format("<th>{0}</th>", columns.ToString()));
            }
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody>");
            foreach (var gridItem in Items.Items)
            {
                sb.Append(String.Format("<tr class='r{0}'>", Items.PrimaryKey.Invoke(gridItem))); //id
                foreach (var columns in Items.Columns)
                {
                    sb.Append(String.Format("<td class='title'>{0}</td>", columns.Invoke(gridItem)));
                }
                
                //edit row
                sb.Append(String.Format("<td><a class='edit' href='#' onClick='EditGame({0});'>Edit</a></td>", Items.PrimaryKey.Invoke(gridItem)));
                sb.Append("</tr>");
            }
            sb.Append("</tbody>");
            sb.Append("</table>");

            return sb.ToString();
        }
    }
}
