using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas.CLI.Models
{
    public class Project
    {
        public int ID { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }

        public bool isActive { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public Client ClientID { get; set; }



        public override string ToString()
        {
            string clientInfo = ClientID != null ? $"Client ID: {ClientID.ID} Client: {ClientID.Name}, Notes:{ClientID.Note}, Active Accountivity: {ClientID.isActive}" : "No Associated Client";
            return $"ID:{ID}. Short Name:{ShortName} Long Name:{LongName}, \nAccount Active:{isActive}. \n" +
                $"Open Date: {OpenDate.ToString("yyyy-MM-dd")}, Close Date: {ClosedDate.ToString("yyyy-MM-dd")}\n" +
                $"Client Info:\n{clientInfo}" ;
        }
    }
}

