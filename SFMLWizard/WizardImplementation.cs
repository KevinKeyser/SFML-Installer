using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;
using EnvDTE;
using SFMLWizard;

namespace SFMLWizard
{
    public class WizardImplementation : IWizard
    {
        // This method is called before opening any item that 
        // has the OpenInEditor attribute.
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
            int removalIndex = project.FullName.LastIndexOf("\\");
            string parentDirectory = project.FullName.Remove(removalIndex, project.FullName.Length - removalIndex);
            Directory.CreateDirectory(parentDirectory + "\\Resources\\Audio");
            Directory.CreateDirectory(parentDirectory + "\\Resources\\Fonts");
            Directory.CreateDirectory(parentDirectory + "\\Resources\\Shaders");
            Directory.CreateDirectory(parentDirectory + "\\Resources\\Textures");
        }

        // This method is only called for item templates,
        // not for project templates.
        public void ProjectItemFinishedGenerating(ProjectItem
            projectItem)
        {
        }

        // This method is called after the project is created.
        public void RunFinished()
        {
        }

        public void RunStarted(object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind, object[] customParams)
        {
        }

        // This method is only called for item templates,
        // not for project templates.
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
