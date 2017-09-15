﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RelhaxModpack
{
    //an enum to control the form editor mode
    public enum EditorMode
    {
        GlobalDependnecy = 0,
        Dependency = 1,
        LogicalDependency = 2,
        DBO = 3,
    };
    public partial class DatabaseEditor : Form
    {
        //basic lists
        private List<Category> ParsedCategoryList;
        private List<Dependency> GlobalDependencies;
        private List<Dependency> Dependencies;
        private List<LogicalDependnecy> LogicalDependencies;
        //other stuff
        private string DatabaseLocation = "";
        private Dependency SelectedGlobalDependency;
        private Dependency SelectedDependency;
        private LogicalDependnecy SelectedLogicalDependency;
        private DatabaseObject SelectedDatabaseObject;
        private Category SelectedCategory;
        private int currentSelectedIndex = -1;
        string GameVersion = "";
        private StringBuilder InUseSB;

        private EditorMode DatabaseEditorMode;

        public DatabaseEditor()
        {
            InitializeComponent();
        }

        private void DatabaseEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.appendToLog("|------------------------------------------------------------------------------------------------|");
        }
        //hook into the database editor loading
        private void DatabaseEditor_Load(object sender, EventArgs e)
        {
            DatabaseEditorMode = EditorMode.GlobalDependnecy;
            ResetUI();
        }
        //loads the database depending on the mode of the radiobuttons
        private void DisplayDatabase()
        {
            if(DatabaseEditorMode == EditorMode.GlobalDependnecy)
            {
                DatabaseTreeView.Nodes.Clear();
                foreach(Dependency d in GlobalDependencies)
                {
                    DatabaseTreeView.Nodes.Add(new DatabaseTreeNode(d, (int)DatabaseEditorMode));
                }
            }
            else if (DatabaseEditorMode == EditorMode.Dependency)
            {
                DatabaseTreeView.Nodes.Clear();
                foreach (Dependency d in Dependencies)
                {
                    DatabaseTreeView.Nodes.Add(new DatabaseTreeNode(d, (int)DatabaseEditorMode));
                }
            }
            else if (DatabaseEditorMode == EditorMode.LogicalDependency)
            {
                DatabaseTreeView.Nodes.Clear();
                foreach (LogicalDependnecy d in LogicalDependencies)
                {
                    DatabaseTreeView.Nodes.Add(new DatabaseTreeNode(d, (int)DatabaseEditorMode));
                }
            }
            else if (DatabaseEditorMode == EditorMode.DBO)
            {
                DatabaseTreeView.Nodes.Clear();
                foreach(Category cat in ParsedCategoryList)
                {
                    DatabaseTreeNode catNode = new DatabaseTreeNode(cat, 4);
                    DatabaseTreeView.Nodes.Add(catNode);
                    foreach(Mod m in cat.mods)
                    {
                        DatabaseTreeNode modNode = new DatabaseTreeNode(m, (int)DatabaseEditorMode);
                        catNode.Nodes.Add(modNode);
                        DisplayDatabaseConfigs(modNode, m.configs);
                    }
                }
            }
            ResetUI();
        }
        private void ResetUI()
        {
            SelectedGlobalDependency = null;
            SelectedDependency = null;
            SelectedLogicalDependency = null;
            SelectedDatabaseObject = null;
            SelectedCategory = null;

            ObjectNameTB.Enabled = false;
            ObjectNameTB.Text = "";

            ObjectPackageNameTB.Enabled = false;
            ObjectPackageNameTB.Text = "";

            ObjectStartAddressTB.Enabled = false;
            ObjectStartAddressTB.Text = "";

            ObjectEndAddressTB.Enabled = false;
            ObjectEndAddressTB.Text = "";

            ObjectZipFileTB.Enabled = false;
            ObjectZipFileTB.Text = "";

            ObjectDevURLTB.Enabled = false;
            ObjectDevURLTB.Text = "";

            ObjectTypeComboBox.Enabled = false;
            ObjectTypeComboBox.SelectedIndex = 0;

            ObjectEnabledCheckBox.Enabled = false;
            ObjectEnabledCheckBox.Checked = false;

            ObjectVisableCheckBox.Enabled = false;
            ObjectVisableCheckBox.Checked = false;

            ObjectAppendExtractionCB.Enabled = false;
            ObjectAppendExtractionCB.Checked = false;

            ObjectDescTB.Enabled = false;
            ObjectDescTB.Text = "";

            ObjectUpdateNotesTB.Enabled = false;
            ObjectUpdateNotesTB.Text = "";

            DatabaseSubeditPanel.Enabled = false;
            PicturePanel.Enabled = false;
        }
        private void DisplayDatabaseConfigs(DatabaseTreeNode parrent, List<Config> configs)
        {
            foreach(Config c in configs)
            {
                DatabaseTreeNode ConfigParrent = new DatabaseTreeNode(c, (int)DatabaseEditorMode);
                parrent.Nodes.Add(ConfigParrent);
                DisplayDatabaseConfigs(ConfigParrent, c.configs);
            }
        }
        //show the load database dialog and load the database
        private void LoadDatabaseButton_Click(object sender, EventArgs e)
        {
            if (OpenDatabaseDialog.ShowDialog() == DialogResult.Cancel)
                return;
            DatabaseLocation = OpenDatabaseDialog.FileName;
            if (!File.Exists(DatabaseLocation))
                return;
            GameVersion = Utils.readVersionFromModInfo(DatabaseLocation);
            GlobalDependencies = new List<Dependency>();
            Dependencies = new List<Dependency>();
            LogicalDependencies = new List<LogicalDependnecy>();
            ParsedCategoryList = new List<Category>();
            Utils.createModStructure(DatabaseLocation, GlobalDependencies, Dependencies, LogicalDependencies, ParsedCategoryList);
            DatabaseEditorMode = EditorMode.GlobalDependnecy;
            this.DisplayDatabase();
        }
        //show the save database dialog and save the database
        private void SaveDatabaseButton_Click(object sender, EventArgs e)
        {
            if (ParsedCategoryList == null || GlobalDependencies == null || Dependencies == null || LogicalDependencies == null)
            {
                MessageBox.Show("Database Not Loaded");
                return;
            }
            if (SaveDatabaseDialog.ShowDialog() == DialogResult.Cancel)
                return;
            DatabaseLocation = SaveDatabaseDialog.FileName;
            Utils.SaveDatabase(DatabaseLocation, GameVersion, GlobalDependencies, Dependencies, LogicalDependencies, ParsedCategoryList);
        }
        //Apply all changes from the form
        private void ApplyChangesButton_Click(object sender, EventArgs e)
        {
            if (ParsedCategoryList == null || GlobalDependencies == null || Dependencies == null || LogicalDependencies == null)
            {
                MessageBox.Show("Database Not Loaded");
                return;
            }
            if (MessageBox.Show("Confirm you wish to apply changes", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            if (DatabaseEditorMode == EditorMode.GlobalDependnecy)
            {
                int index = GlobalDependencies.IndexOf(SelectedGlobalDependency);
                SelectedGlobalDependency.packageName = ObjectPackageNameTB.Text;
                SelectedGlobalDependency.startAddress = ObjectStartAddressTB.Text;
                SelectedGlobalDependency.endAddress = ObjectEndAddressTB.Text;
                SelectedGlobalDependency.dependencyZipFile = ObjectZipFileTB.Text;
                SelectedGlobalDependency.enabled = ObjectEnabledCheckBox.Checked;
                SelectedGlobalDependency.appendExtraction = ObjectAppendExtractionCB.Checked;
                GlobalDependencies[index] = SelectedGlobalDependency;
            }
            else if (DatabaseEditorMode == EditorMode.Dependency)
            {
                int index = Dependencies.IndexOf(SelectedDependency);
                SelectedDependency.packageName = ObjectPackageNameTB.Text;
                SelectedDependency.startAddress = ObjectStartAddressTB.Text;
                SelectedDependency.endAddress = ObjectEndAddressTB.Text;
                SelectedDependency.dependencyZipFile = ObjectZipFileTB.Text;
                SelectedDependency.enabled = ObjectEnabledCheckBox.Checked;
                SelectedDependency.appendExtraction = ObjectAppendExtractionCB.Checked;
                Dependencies[index] = SelectedDependency;
            }
            else if (DatabaseEditorMode == EditorMode.LogicalDependency)
            {
                int index = LogicalDependencies.IndexOf(SelectedLogicalDependency);
                SelectedLogicalDependency.packageName = ObjectPackageNameTB.Text;
                SelectedLogicalDependency.startAddress = ObjectStartAddressTB.Text;
                SelectedLogicalDependency.endAddress = ObjectEndAddressTB.Text;
                SelectedLogicalDependency.dependencyZipFile = ObjectZipFileTB.Text;
                SelectedLogicalDependency.enabled = ObjectEnabledCheckBox.Checked;
                LogicalDependencies[index] = SelectedLogicalDependency;
            }
            else if (DatabaseEditorMode == EditorMode.DBO)
            {
               //TODO
               if(SelectedDatabaseObject is Mod)
                {

                }
                else if (SelectedDatabaseObject is Config)
                {

                }
            }
        }
        private List<Mod> ListContainsDBO(DatabaseObject DBO)
        {
            Mod mod = (Mod)DBO;
            foreach(Category cat in ParsedCategoryList)
            {
                if (cat.mods.Contains(mod))
                    return cat.mods;
                foreach(Mod m in cat.mods)
                {
                    
                }
            }
            return null;
        }
        //mode set to globalDependency
        private void GlobalDependencyRB_CheckedChanged(object sender, EventArgs e)
        {
            if (ParsedCategoryList == null || GlobalDependencies == null || Dependencies == null || LogicalDependencies == null)
            {
                MessageBox.Show("Database Not Loaded");
                return;
            }
            RadioButton rb1 = (RadioButton)sender;
            if (rb1.Checked)
            {
                DatabaseEditorMode = EditorMode.GlobalDependnecy;
                DisplayDatabase();
            }
        }
        //mode set to dependency
        private void DependencyRB_CheckedChanged(object sender, EventArgs e)
        {
            if (ParsedCategoryList == null || GlobalDependencies == null || Dependencies == null || LogicalDependencies == null)
            {
                MessageBox.Show("Database Not Loaded");
                return;
            }
            RadioButton rb1 = (RadioButton)sender;
            if (rb1.Checked)
            {
                DatabaseEditorMode = EditorMode.Dependency;
                DisplayDatabase();
            }
        }
        //mode set to logicalDependency
        private void LogicalDependencyRB_CheckedChanged(object sender, EventArgs e)
        {
            if (ParsedCategoryList == null || GlobalDependencies == null || Dependencies == null || LogicalDependencies == null)
            {
                MessageBox.Show("Database Not Loaded");
                return;
            }
            RadioButton rb1 = (RadioButton)sender;
            if (rb1.Checked)
            {
                DatabaseEditorMode = EditorMode.LogicalDependency;
                DisplayDatabase();
            }
        }
        //mode set to DBO
        private void DBO_CheckedChanged(object sender, EventArgs e)
        {
            if (ParsedCategoryList == null || GlobalDependencies == null || Dependencies == null || LogicalDependencies == null)
            {
                MessageBox.Show("Database Not Loaded");
                return;
            }
            RadioButton rb1 = (RadioButton)sender;
            if (rb1.Checked)
            {
                DatabaseEditorMode = EditorMode.DBO;
                DisplayDatabase();
            }
        }

        private void DatabaseTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            DatabaseTreeView.SelectedNode = e.Node;
            currentSelectedIndex = DatabaseTreeView.SelectedNode.Index;
            //DatabaseTreeView.SelectedNode.BackColor = Color.Blue;
            //DatabaseTreeView.SelectedNode.ForeColor = Color.Blue;
            DatabaseTreeNode node = (DatabaseTreeNode)DatabaseTreeView.SelectedNode;
            if(node.GlobalDependency != null)
            {
                SelectedGlobalDependency = node.GlobalDependency;
                SelectedDependency = null;
                SelectedLogicalDependency = null;
                SelectedDatabaseObject = null;
                SelectedCategory = null;

                ObjectNameTB.Enabled = false;
                ObjectNameTB.Text = "";

                ObjectPackageNameTB.Enabled = true;
                ObjectPackageNameTB.Text = node.GlobalDependency.packageName;

                ObjectStartAddressTB.Enabled = true;
                ObjectStartAddressTB.Text = node.GlobalDependency.startAddress;

                ObjectEndAddressTB.Enabled = true;
                ObjectEndAddressTB.Text = node.GlobalDependency.endAddress;

                ObjectZipFileTB.Enabled = true;
                ObjectZipFileTB.Text = node.GlobalDependency.dependencyZipFile;

                ObjectDevURLTB.Enabled = false;
                ObjectDevURLTB.Text = "";

                ObjectTypeComboBox.Enabled = false;
                ObjectTypeComboBox.SelectedIndex = 0;

                ObjectEnabledCheckBox.Enabled = true;
                ObjectEnabledCheckBox.Checked = node.GlobalDependency.enabled;

                ObjectVisableCheckBox.Enabled = false;
                ObjectVisableCheckBox.Checked = false;

                ObjectAppendExtractionCB.Enabled = true;
                ObjectAppendExtractionCB.Checked = node.GlobalDependency.appendExtraction;

                ObjectDescTB.Enabled = false;
                ObjectDescTB.Text = "";

                ObjectUpdateNotesTB.Enabled = false;
                ObjectUpdateNotesTB.Text = "";

                DatabaseSubeditPanel.Enabled = false;
                PicturePanel.Enabled = false;
            }
            else if (node.Dependency != null)
            {
                SelectedGlobalDependency = null;
                SelectedDependency = node.Dependency;
                SelectedLogicalDependency = null;
                SelectedDatabaseObject = null;
                SelectedCategory = null;

                ObjectNameTB.Enabled = false;
                ObjectNameTB.Text = "";

                ObjectPackageNameTB.Enabled = true;
                ObjectPackageNameTB.Text = SelectedDependency.packageName;

                ObjectStartAddressTB.Enabled = true;
                ObjectStartAddressTB.Text = SelectedDependency.startAddress;

                ObjectEndAddressTB.Enabled = true;
                ObjectEndAddressTB.Text = SelectedDependency.endAddress;

                ObjectZipFileTB.Enabled = true;
                ObjectZipFileTB.Text = SelectedDependency.dependencyZipFile;

                ObjectDevURLTB.Enabled = false;
                ObjectDevURLTB.Text = "";

                ObjectTypeComboBox.Enabled = false;
                ObjectTypeComboBox.SelectedIndex = 0;

                ObjectEnabledCheckBox.Enabled = true;
                ObjectEnabledCheckBox.Checked = SelectedDependency.enabled;

                ObjectVisableCheckBox.Enabled = false;
                ObjectVisableCheckBox.Checked = false;

                ObjectAppendExtractionCB.Enabled = true;
                ObjectAppendExtractionCB.Checked = SelectedDependency.appendExtraction;

                ObjectDescTB.Enabled = false;
                ObjectDescTB.Text = "";

                ObjectUpdateNotesTB.Enabled = false;
                ObjectUpdateNotesTB.Text = "";

                DatabaseSubeditPanel.Enabled = true;
                DependencyPanel.Enabled = false;

                LogicalDependencyPanel.Enabled = true;
                ObjectLogicalDependenciesList.DataSource = null;
                ObjectLogicalDependenciesList.Items.Clear();
                ObjectLogicalDependenciesList.DataSource = SelectedDependency.logicalDependencies;
                CurrentLogicalDependenciesCB.DataSource = LogicalDependencies;
                CurrentLogicalDependenciesCB.SelectedIndex = -1;
                LogicalDependnecyNegateFlagCB.CheckedChanged -= LogicalDependnecyNegateFlagCB_CheckedChanged;
                LogicalDependnecyNegateFlagCB.Checked = false;
                LogicalDependnecyNegateFlagCB.CheckedChanged += LogicalDependnecyNegateFlagCB_CheckedChanged;

                PicturePanel.Enabled = false;
            }
            else if (node.LogicalDependency != null)
            {
                SelectedGlobalDependency = null;
                SelectedDependency = null;
                SelectedLogicalDependency = node.LogicalDependency;
                SelectedDatabaseObject = null;
                SelectedCategory = null;

                ObjectNameTB.Enabled = false;
                ObjectNameTB.Text = "";

                ObjectPackageNameTB.Enabled = true;
                ObjectPackageNameTB.Text = SelectedLogicalDependency.packageName;

                ObjectStartAddressTB.Enabled = true;
                ObjectStartAddressTB.Text = SelectedLogicalDependency.startAddress;

                ObjectEndAddressTB.Enabled = true;
                ObjectEndAddressTB.Text = SelectedLogicalDependency.endAddress;

                ObjectZipFileTB.Enabled = true;
                ObjectZipFileTB.Text = SelectedLogicalDependency.dependencyZipFile;

                ObjectDevURLTB.Enabled = false;
                ObjectDevURLTB.Text = "";

                ObjectTypeComboBox.Enabled = false;
                ObjectTypeComboBox.SelectedIndex = 0;

                ObjectEnabledCheckBox.Enabled = true;
                ObjectEnabledCheckBox.Checked = SelectedLogicalDependency.enabled;

                ObjectVisableCheckBox.Enabled = false;
                ObjectVisableCheckBox.Checked = false;

                ObjectAppendExtractionCB.Enabled = false;
                ObjectAppendExtractionCB.Checked = false;

                ObjectDescTB.Enabled = false;
                ObjectDescTB.Text = "";

                ObjectUpdateNotesTB.Enabled = false;
                ObjectUpdateNotesTB.Text = "";

                DatabaseSubeditPanel.Enabled = false;
                PicturePanel.Enabled = false;
            }
            else if (node.DatabaseObject != null)
            {
                //TODO
            }
            else if (node.Category != null)
            {
                //TODO
                SelectedGlobalDependency = null;
                SelectedDependency = null;
                SelectedLogicalDependency = null;
                SelectedDatabaseObject = null;
                SelectedCategory = node.Category;

                ObjectNameTB.Enabled = true;
                ObjectNameTB.Text = SelectedCategory.name;

                ObjectPackageNameTB.Enabled = false;
                ObjectPackageNameTB.Text = "";

                ObjectStartAddressTB.Enabled = false;
                ObjectStartAddressTB.Text = "";

                ObjectEndAddressTB.Enabled = false;
                ObjectEndAddressTB.Text = "";

                ObjectZipFileTB.Enabled = false;
                ObjectZipFileTB.Text ="";

                ObjectDevURLTB.Enabled = false;
                ObjectDevURLTB.Text = "";

                ObjectTypeComboBox.Enabled = false;
                ObjectTypeComboBox.SelectedIndex = 0;

                ObjectEnabledCheckBox.Enabled = false;
                ObjectEnabledCheckBox.Checked = false;

                ObjectVisableCheckBox.Enabled = false;
                ObjectVisableCheckBox.Checked = false;

                ObjectAppendExtractionCB.Enabled = false;
                ObjectAppendExtractionCB.Checked = false;

                ObjectDescTB.Enabled = false;
                ObjectDescTB.Text = "";

                ObjectUpdateNotesTB.Enabled = false;
                ObjectUpdateNotesTB.Text = "";

                DatabaseSubeditPanel.Enabled = true;
                DependencyPanel.Enabled = true;
                LogicalDependencyPanel.Enabled = false;

                ObjectDependenciesList.DataSource = null;
                ObjectDependenciesList.Items.Clear();
                ObjectDependenciesList.DataSource = SelectedCategory.dependencies;
                CurrentDependenciesCB.DataSource = Dependencies;
                CurrentDependenciesCB.SelectedIndex = -1;

                PicturePanel.Enabled = false;
            }
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            if (ParsedCategoryList == null || GlobalDependencies == null || Dependencies == null || LogicalDependencies == null)
            {
                MessageBox.Show("Database Not Loaded");
                return;
            }
            using (DatabaseAdder dba = new DatabaseAdder(DatabaseEditorMode, GlobalDependencies, Dependencies, LogicalDependencies, ParsedCategoryList))
            {
                dba.ShowDialog();
                if (DatabaseEditorMode == EditorMode.GlobalDependnecy)
                {
                    if (dba.SelectedGlobalDependency == null)
                        return;
                    GlobalDependencies.Remove(SelectedGlobalDependency);
                    int index = GlobalDependencies.IndexOf(dba.SelectedGlobalDependency);
                    GlobalDependencies.Insert(index, SelectedGlobalDependency);
                    DisplayDatabase();
                }
                else if (DatabaseEditorMode == EditorMode.Dependency)
                {
                    if (dba.SelectedDependency == null)
                        return;
                    Dependencies.Remove(SelectedDependency);
                    int index = Dependencies.IndexOf(dba.SelectedDependency);
                    Dependencies.Insert(index, SelectedDependency);
                    DisplayDatabase();
                }
                else if (DatabaseEditorMode == EditorMode.LogicalDependency)
                {
                    if (dba.SelectedLogicalDependency == null)
                        return;
                    LogicalDependencies.Remove(SelectedLogicalDependency);
                    int index = LogicalDependencies.IndexOf(dba.SelectedLogicalDependency);
                    LogicalDependencies.Insert(index, SelectedLogicalDependency);
                    DisplayDatabase();
                }
                else if (DatabaseEditorMode == EditorMode.DBO)
                {
                    //TODO
                }
            }
        }

        private void AddEntryButton_Click(object sender, EventArgs e)
        {
            if(ParsedCategoryList == null || GlobalDependencies == null || Dependencies == null || LogicalDependencies == null)
            {
                MessageBox.Show("Database Not Loaded");
                return;
            }
            using (DatabaseAdder dba = new DatabaseAdder(DatabaseEditorMode, GlobalDependencies, Dependencies, LogicalDependencies, ParsedCategoryList))
            {
                dba.ShowDialog();
                if (DatabaseEditorMode == EditorMode.GlobalDependnecy)
                {
                    if (dba.SelectedGlobalDependency == null)
                        return;
                    Dependency newDep = new Dependency();
                    newDep.packageName = ObjectPackageNameTB.Text;
                    newDep.startAddress = ObjectStartAddressTB.Text;
                    newDep.endAddress = ObjectEndAddressTB.Text;
                    newDep.dependencyZipFile = ObjectZipFileTB.Text;
                    newDep.enabled = ObjectEnabledCheckBox.Checked;
                    newDep.appendExtraction = ObjectAppendExtractionCB.Checked;
                    int index = GlobalDependencies.IndexOf(dba.SelectedGlobalDependency);
                    GlobalDependencies.Insert(index, newDep);
                    DisplayDatabase();
                }
                else if (DatabaseEditorMode == EditorMode.Dependency)
                {
                    if (dba.SelectedDependency == null)
                        return;
                    Dependency newDep = new Dependency();
                    newDep.packageName = ObjectPackageNameTB.Text;
                    newDep.startAddress = ObjectStartAddressTB.Text;
                    newDep.endAddress = ObjectEndAddressTB.Text;
                    newDep.dependencyZipFile = ObjectZipFileTB.Text;
                    newDep.enabled = ObjectEnabledCheckBox.Checked;
                    newDep.appendExtraction = ObjectAppendExtractionCB.Checked;
                    List<LogicalDependnecy> logicalDeps = (List<LogicalDependnecy>)ObjectLogicalDependenciesList.DataSource;
                    int index = Dependencies.IndexOf(dba.SelectedDependency);
                    Dependencies.Insert(index, newDep);
                    DisplayDatabase();
                }
                else if (DatabaseEditorMode == EditorMode.LogicalDependency)
                {
                    if (dba.SelectedLogicalDependency == null)
                        return;
                    LogicalDependnecy newDep = new LogicalDependnecy();
                    newDep.packageName = ObjectPackageNameTB.Text;
                    newDep.startAddress = ObjectStartAddressTB.Text;
                    newDep.endAddress = ObjectEndAddressTB.Text;
                    newDep.dependencyZipFile = ObjectZipFileTB.Text;
                    newDep.enabled = ObjectEnabledCheckBox.Checked;
                    int index = LogicalDependencies.IndexOf(dba.SelectedLogicalDependency);
                    LogicalDependencies.Insert(index, newDep);
                    DisplayDatabase();
                }
                else if (DatabaseEditorMode == EditorMode.DBO)
                {
                    //TODO
                }
            }
        }

        private void RemoveEntryButton_Click(object sender, EventArgs e)
        {
            if (ParsedCategoryList == null || GlobalDependencies == null || Dependencies == null || LogicalDependencies == null)
            {
                MessageBox.Show("Database Not Loaded");
                return;
            }
            if (MessageBox.Show("Confirm you wish to remove the object?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            if (DatabaseEditorMode == EditorMode.GlobalDependnecy)
            {
                GlobalDependencies.Remove(SelectedGlobalDependency);
            }
            else if (DatabaseEditorMode == EditorMode.Dependency)
            {
                //check if the dependency is in use first
                if(DependencyInUse(SelectedDependency.packageName,true))
                {
                    MessageBox.Show("Cannot remove because it is in use:\n" + InUseSB.ToString());
                }
                else
                {
                    Dependencies.Remove(SelectedDependency);
                }
            }
            else if (DatabaseEditorMode == EditorMode.LogicalDependency)
            {
                //check if the dependency is in use first
                if(DependencyInUse(SelectedLogicalDependency.packageName,false))
                {
                    MessageBox.Show("Cannot remove because it is in use:\n" + InUseSB.ToString());
                }
                else
                {
                    LogicalDependencies.Remove(SelectedLogicalDependency);
                }
            }
            else if (DatabaseEditorMode == EditorMode.DBO)
            {
                //TODO
            }
            DisplayDatabase();
        }

        private bool DependencyInUse(string packageName, bool isDependency)
        {
            InUseSB = new StringBuilder();
            bool InUse = false;
            if (!isDependency)
            {
                foreach (Dependency d in Dependencies)
                {
                    if (d.packageName.Equals(packageName))
                    {
                        InUse = true;
                        InUseSB.Append("Dependency: " + d.packageName + "\n");
                    }
                }
            }
            foreach(Category c in ParsedCategoryList)
            {
                foreach(Dependency d in c.dependencies)
                {
                    if (d.packageName.Equals(packageName))
                    {
                        InUse = true;
                        InUseSB.Append("Category: " + c.name);
                    }
                }
                foreach(Mod m in c.mods)
                {
                    foreach(Dependency d in m.dependencies)
                    {
                        if(d.packageName.Equals(packageName))
                        {
                            InUse = true;
                            InUseSB.Append("Mod: " + m.packageName + "\n");
                        }
                    }
                    foreach(LogicalDependnecy d in m.logicalDependencies)
                    {
                        if (d.packageName.Equals(packageName))
                        {
                            InUse = true;
                            InUseSB.Append("Mod: " + m.packageName + "\n");
                        }
                    }
                    ProcessConfigsInUse(InUseSB, m.configs, InUse, packageName);
                }
            }
            return InUse;
        }
        private void ProcessConfigsInUse(StringBuilder sb, List<Config> configs, bool InUse, string packageName)
        {
            foreach(Config c in configs)
            {
                foreach(Dependency d in c.dependencies)
                {
                    if (d.packageName.Equals(packageName))
                    {
                        InUse = true;
                        InUseSB.Append("Config: " + c.packageName + "\n");
                    }
                }
                foreach(LogicalDependnecy d in c.logicalDependencies)
                {
                    if (d.packageName.Equals(packageName))
                    {
                        InUse = true;
                        InUseSB.Append("Config: " + c.packageName + "\n");
                    }
                }
                ProcessConfigsInUse(sb, c.configs, InUse, packageName);
            }
        }

        private void AddDependencyButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm you wish to add dependency", "confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            if (SelectedCategory != null)
            {
                Dependency ld = new Dependency();
                Dependency ld2 = (Dependency)CurrentDependenciesCB.SelectedItem;
                ld.packageName = ld2.packageName;
                SelectedCategory.dependencies.Add(ld);
                ObjectDependenciesList.DataSource = null;
                ObjectDependenciesList.Items.Clear();
                ObjectDependenciesList.DataSource = SelectedCategory.dependencies;
            }
            else if (DatabaseEditorMode == EditorMode.DBO)
            {
                Dependency ld = new Dependency();
                Dependency ld2 = (Dependency)CurrentDependenciesCB.SelectedItem;
                ld.packageName = ld2.packageName;
                SelectedDatabaseObject.dependencies.Add(ld);
                ObjectDependenciesList.DataSource = null;
                ObjectDependenciesList.Items.Clear();
                ObjectDependenciesList.DataSource = SelectedDatabaseObject.dependencies;
            }
        }

        private void RemoveDependencyButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm you wish to remove dependency", "confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            if (SelectedCategory != null)
            {
                SelectedCategory.dependencies.Remove((Dependency)ObjectDependenciesList.SelectedItem);
                ObjectDependenciesList.DataSource = null;
                ObjectDependenciesList.Items.Clear();
                ObjectDependenciesList.DataSource = SelectedCategory.dependencies;
            }
            else if (DatabaseEditorMode == EditorMode.DBO)
            {
                SelectedDatabaseObject.dependencies.Remove((Dependency)ObjectDependenciesList.SelectedItem);
                ObjectDependenciesList.DataSource = null;
                ObjectDependenciesList.Items.Clear();
                ObjectDependenciesList.DataSource = SelectedDatabaseObject.dependencies;
            } 
        }

        private void AddLogicalDependencyButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm you wish to add logical dependency", "confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            if (DatabaseEditorMode == EditorMode.Dependency)
            {
                LogicalDependnecy ld = new LogicalDependnecy();
                LogicalDependnecy ld2 = (LogicalDependnecy)CurrentLogicalDependenciesCB.SelectedItem;
                ld.packageName = ld2.packageName;
                ld.negateFlag = LogicalDependnecyNegateFlagCB.Checked;
                SelectedDependency.logicalDependencies.Add(ld);
                ObjectLogicalDependenciesList.DataSource = null;
                ObjectLogicalDependenciesList.Items.Clear();
                ObjectLogicalDependenciesList.DataSource = SelectedDependency.logicalDependencies;
            }
            else if (DatabaseEditorMode == EditorMode.DBO)
            {
                LogicalDependnecy ld = new LogicalDependnecy();
                LogicalDependnecy ld2 = (LogicalDependnecy)CurrentLogicalDependenciesCB.SelectedItem;
                ld.packageName = ld2.packageName;
                ld.negateFlag = LogicalDependnecyNegateFlagCB.Checked;
                SelectedDatabaseObject.logicalDependencies.Add(ld);
                ObjectLogicalDependenciesList.DataSource = null;
                ObjectLogicalDependenciesList.Items.Clear();
                ObjectLogicalDependenciesList.DataSource = SelectedDatabaseObject.logicalDependencies;
            }
        }

        private void RemoveLogicalDependencyButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm you wish to remove logical dependency", "confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            if (DatabaseEditorMode == EditorMode.Dependency)
            {
                SelectedDependency.logicalDependencies.Remove((LogicalDependnecy)ObjectLogicalDependenciesList.SelectedItem);
                ObjectLogicalDependenciesList.DataSource = null;
                ObjectLogicalDependenciesList.Items.Clear();
                ObjectLogicalDependenciesList.DataSource = SelectedDependency.logicalDependencies;
            }
            else if (DatabaseEditorMode == EditorMode.DBO)
            {
                SelectedDatabaseObject.logicalDependencies.Remove((LogicalDependnecy)ObjectLogicalDependenciesList.SelectedItem);
                ObjectLogicalDependenciesList.DataSource = null;
                ObjectLogicalDependenciesList.Items.Clear();
                ObjectLogicalDependenciesList.DataSource = SelectedDatabaseObject.logicalDependencies;
            }
        }

        private void MovePictureButton_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void AddPictureButton_Click(object sender, EventArgs e)
        {
           //TODO
        }

        private void RemovePictureButton_Click(object sender, EventArgs e)
        {
           //TODO
        }

        private void ApplyPictureEditButton_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void ObjectLogicalDependenciesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            if (lb.DataSource == null)
                return;
            LogicalDependnecy ld = (LogicalDependnecy)lb.SelectedItem;
            foreach(LogicalDependnecy d in LogicalDependencies)
            {
                if(d.packageName.Equals(ld.packageName))
                {
                    CurrentLogicalDependenciesCB.SelectedItem = d;
                    break;
                }
            }
            LogicalDependnecyNegateFlagCB.CheckedChanged -= LogicalDependnecyNegateFlagCB_CheckedChanged;
            LogicalDependnecyNegateFlagCB.Checked = ld.negateFlag;
            LogicalDependnecyNegateFlagCB.CheckedChanged += LogicalDependnecyNegateFlagCB_CheckedChanged;
        }

        private void LogicalDependnecyNegateFlagCB_CheckedChanged(object sender, EventArgs e)
        {
            if (MessageBox.Show("change logical dependency negate flag status (yes) or change flag status for adding new logical dependency (no)", "confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            if (DatabaseEditorMode == EditorMode.Dependency)
            {
                LogicalDependnecy ld = (LogicalDependnecy)ObjectLogicalDependenciesList.SelectedItem;
                ld.negateFlag = LogicalDependnecyNegateFlagCB.Checked;
                ObjectLogicalDependenciesList.DataSource = null;
                ObjectLogicalDependenciesList.Items.Clear();
                ObjectLogicalDependenciesList.DataSource = SelectedDependency.logicalDependencies;
            }
            else if (DatabaseEditorMode == EditorMode.DBO)
            {
                //TODO:TEST
                LogicalDependnecy ld = (LogicalDependnecy)ObjectLogicalDependenciesList.SelectedItem;
                ld.negateFlag = LogicalDependnecyNegateFlagCB.Checked;
                ObjectLogicalDependenciesList.DataSource = null;
                ObjectLogicalDependenciesList.Items.Clear();
                ObjectLogicalDependenciesList.DataSource = SelectedDatabaseObject.logicalDependencies;
            }
        }

        private void ObjectDependenciesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            if (lb.DataSource == null)
                return;
            Dependency ld = (Dependency)lb.SelectedItem;
            foreach (Dependency d in Dependencies)
            {
                if (d.packageName.Equals(ld.packageName))
                {
                    CurrentDependenciesCB.SelectedItem = d;
                    break;
                }
            }
        }
    }
}
