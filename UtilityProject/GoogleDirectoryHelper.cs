using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilityProject
{
    public class GoogleDirectoryHelper
    {
        private static List<DirectoryNode> GoogleRuleDirectories;// all attribute values should be lower case

       static GoogleDirectoryHelper()
        {
            GoogleRuleDirectories = new List<DirectoryNode>();
            Load();
        }

        public static bool Load()
        {
            GoogleRuleDirectories.Clear();
            /*
             * 
             * // for each change in file being created or removed or edited. two changes are returned one is folder under which changes was made and then the actual changes
             
                //while a new rule is created
                    get parent directory of current directory to create DirectoryNode object to be added in GoogleRuleDirectories with rule Guid of rule
                    get all child directory recursively to be added in GoogleRuleDirectories with parents and NULL rule guid ? or rule guid or rule being created if yes then we need to introduce one flag in DirectoryInfo object to show the direcotry node is directly related to a rule?
                    save this information back to physical file
                
                // while a rule is edited
                    check the current directory matches with old directory if yest then change the rule guid in all places as when rule is edited then a new rule is created by removing old rule 
                    check if current direcotry is different from old directory then remove all information from GoogleRuleDirectories  recursively for all sub folders. WHAT IF sub folder have rule seperatly
                    add directory and child directories in GoogleRuleDirectories by checking if not exists
                // while rule is removed
                    remove all information from GoogleRuleDirectories recursively for all sub folders. WHAT IF sub folder have rule seperatly
                
                // a file is being added and received as change
                    search for rule on directory, if not found then parent directories recursive till top folder comes or Ruld guid is found at some point 
                        if rule guid is found then process the file for protection under that's rules policy
                        if rule guid is not found then do not process that file for protection
                
                //if a new folder is being added/remove under some folder and received as change
                    check folder id already exists in GoogleRuleDirectories, it should not
                    get parent folder id to check for rule , and find recursively till rule is found, then add/remove this directory node in GoogleRuleDirectories, otherwise skip folder


            */


            //load file where this information is saved to populate GoogleDirectories

            /*
             * Rule on root folder (no rule on sub folder)
             *      Rule on parent folder, create rule on child folder at any level (one of parent folder already have rule)
             * Rule on leaf folder (last sub folder) , no rule on any parent folder
             *      Rule on sub folder , create rule on any of folder above sub folder
             * 
             A
             B
                F(R1)
                    G
                        H
             C
                D
                E
                    I
                J
             
            K
            L
                M
             */

            GoogleRuleDirectories.Add(new DirectoryNode { Directory = "A", ParentDirectory = string.Empty, RuleGuid = "" });
            GoogleRuleDirectories.Add(new DirectoryNode { Directory = "B", ParentDirectory = string.Empty, RuleGuid = "" });
            GoogleRuleDirectories.Add(new DirectoryNode { Directory = "C", ParentDirectory = string.Empty, RuleGuid = "" });
            GoogleRuleDirectories.Add(new DirectoryNode { Directory = "D", ParentDirectory = "C", RuleGuid = "" });
            GoogleRuleDirectories.Add(new DirectoryNode { Directory = "E", ParentDirectory = "C", RuleGuid = "" });
            GoogleRuleDirectories.Add(new DirectoryNode { Directory = "F", ParentDirectory = "B", RuleGuid = "R1" });
            GoogleRuleDirectories.Add(new DirectoryNode { Directory = "G", ParentDirectory = "F", RuleGuid = "" });
            GoogleRuleDirectories.Add(new DirectoryNode { Directory = "H", ParentDirectory = "G", RuleGuid = "" });
            GoogleRuleDirectories.Add(new DirectoryNode { Directory = "I", ParentDirectory = "E", RuleGuid = "" });
            GoogleRuleDirectories.Add(new DirectoryNode { Directory = "J", ParentDirectory = "E", RuleGuid = "" });
            GoogleRuleDirectories.Add(new DirectoryNode { Directory = "L", ParentDirectory = string.Empty, RuleGuid = "" });
            GoogleRuleDirectories.Add(new DirectoryNode { Directory = "M", ParentDirectory = "L", RuleGuid = "" });







            return true;
        }

        public static List<DirectoryNode> GetByParentDirectoryName(string parentDirectory, bool recursiveToTop)
        {
            parentDirectory = parentDirectory.ToLower();
            List<DirectoryNode> dirList = new List<DirectoryNode>();
            dirList = GoogleRuleDirectories.Where(d => d.ParentDirectory == parentDirectory).ToList();
            return dirList;
        }
        public static DirectoryNode GetByDirectoryName(string directory)
        {
            directory = directory.ToLower();
            return GoogleRuleDirectories.SingleOrDefault(d => d.Directory == directory);
        }

        public static bool FindRule(string directoryOfFile, out DirectoryNode dirInfo, bool recursiveToTop = true)
        {
            bool found = false;
            //dirInfo = null;
            //DirectoryHierarchy2 dir = new DirectoryHierarchy2();
            directoryOfFile = directoryOfFile.ToLower();
            if (!recursiveToTop)
            {
                dirInfo = GoogleRuleDirectories.SingleOrDefault(d => d.Directory == directoryOfFile );
                if (dirInfo != null && !string.IsNullOrEmpty(dirInfo.RuleGuid))
                {
                    found = true;
                }
            }
            else
            {
                dirInfo = GoogleRuleDirectories.SingleOrDefault(d => d.Directory == directoryOfFile);
                string parentDirectory = string.Empty;
                if (dirInfo != null && dirInfo != default(DirectoryNode))
                {
                    parentDirectory = dirInfo.ParentDirectory;
                    if (!string.IsNullOrEmpty(dirInfo.RuleGuid))
                    {
                        found = true;
                    }
                }
                do
                {
                    dirInfo = GoogleRuleDirectories.SingleOrDefault(d => d.Directory == parentDirectory);
                    if (dirInfo != null && dirInfo != default(DirectoryNode))
                    {
                        parentDirectory = dirInfo.ParentDirectory;
                        if (!string.IsNullOrEmpty(dirInfo.RuleGuid))
                        {
                            found = true;
                            break;
                        }
                    }
                    else
                    {
                        parentDirectory = string.Empty;
                    }
                    dirInfo = null;
                } while (!string.IsNullOrEmpty(parentDirectory));
            }
            return found;
        }

        public static bool Add(DirectoryNode directoryNode)
        {
            directoryNode.Directory = directoryNode.Directory.ToLower();
            directoryNode.ParentDirectory = directoryNode.ParentDirectory.ToLower();
            directoryNode.RuleGuid = directoryNode.RuleGuid.ToLower();

            if (!GoogleRuleDirectories.Any(s=> s.RuleGuid == directoryNode.RuleGuid))
            {
                GoogleRuleDirectories.Add(directoryNode);
                return true;
            }
            return false;
        }
        public static bool Add(string directory, string parentDirectory, string ruleGuid)
        {
            if (!GoogleRuleDirectories.Any(s => s.RuleGuid == ruleGuid.ToLower()))
            {
                GoogleRuleDirectories.Add(new DirectoryNode { Directory = directory.ToLower(), ParentDirectory = parentDirectory.ToLower(), RuleGuid = ruleGuid.ToLower() });
                return true;
            }
            return false;
        }
    }
}
