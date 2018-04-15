using System.Collections.Generic;

namespace LinqSimplee
{
    public class KsiegaCzarowList : List<Czar>
    {
        public override string ToString()
        {
            var message = "{";
            foreach (var item in this)
            {
                message += "{" + item.ToString() + "},";
            }
            message += "}";

            return message;
        }
    }
}
