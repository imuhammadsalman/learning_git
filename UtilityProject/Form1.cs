using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UtilityProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTestRegex_Click(object sender, EventArgs e)
        {
            string regex = txtRegex.Text;
            string testingText = txtTestString.Text;
            string matchValue = string.Empty;
            Match m = Regex.Match(testingText, @".*[^-\w]([-\w]{25,})[^-\w]?.*");
            if (m.Success)
            {
                if (m.Groups != null && m.Groups.Count > 1)
                {
                    matchValue = m.Groups[1].Value;
                }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            DirectoryNode dirInfo;
            bool ruleFound = false;
            ruleFound = GoogleDirectoryHelper.FindRule("I", out dirInfo);
            ruleFound = GoogleDirectoryHelper.FindRule("H", out dirInfo);

            //DirectoryNode directoryNode = new DirectoryNode { Directory ="Z", ParentDirectory = "B", RuleGuid = string.Empty };

            

            //------------------------------------------------------------------------------------------------

            //List<DirectoryHierarchy> lstDir = new List<DirectoryHierarchy>();
            //lstDir.Add(new DirectoryHierarchy { Folder = "A", ParentFolder = string.Empty, Files = new List<string> { "1", "2" } });
            //lstDir.Add(new DirectoryHierarchy { Folder = "B", ParentFolder = string.Empty, Files = new List<string> { "3", "4" } });
            //lstDir.Add(new DirectoryHierarchy { Folder = "C", ParentFolder = string.Empty, Files = new List<string> { "5", "6" } });
            //lstDir.Add(new DirectoryHierarchy { Folder = "D", ParentFolder = "C", Files = new List<string> { "7", "8" } });
            //lstDir.Add(new DirectoryHierarchy { Folder = "E", ParentFolder = "C", Files = new List<string> { "9", "10" } });
            //lstDir.Add(new DirectoryHierarchy { Folder = "F", ParentFolder = "B", Files = new List<string> { "11", "12" } });

            ////find fileId = 8

            //var obj = lstDir.Where(d => d.Files.Any(f => f == "8"));
            ////find file with id "8888"
            //var obj2 = lstDir.Where(d => d.Files.Any(f => f == "8888"));

            ////find folder with id "B"
            //var obj3 = lstDir.Where(d => d.Folder == "B");


            //------------------------------------------------------------------------------------------------
            //Dictionary<string, User> dic = new Dictionary<string, User>();
            //dic.Add("1", new User { ID = "id1", Name = "name1" });
            //dic.Add("2", new User { ID = "id2", Name = "name2" });
            //dic.Add("3", new User { ID = "id3", Name = "name3" });

            //var user = dic.FirstOrDefault(z => z.Value.ID == "id2");
            //var user2= dic.FirstOrDefault(z => z.Value.ID == "id4");
        }
    }

    //public class DirectoryHierarchy
    //{
    //    public string ParentFolder { get; set; }
    //    public string Folder { get; set; }
    //    public List<string> Files { get; set; }
    //}

    public class DirectoryNode
    {
        public string RuleGuid { get; set; }
        public string Directory { get; set; }
        public string ParentDirectory { get; set; }
    }

    
    //internal class User
    //{
    //    public string ID { get; set; }

    //    public string Name { get; set; }
    //}
}
