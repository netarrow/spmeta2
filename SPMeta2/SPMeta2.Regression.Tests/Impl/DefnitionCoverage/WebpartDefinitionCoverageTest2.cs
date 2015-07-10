﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Containers;
using SPMeta2.Containers.Standard;
using SPMeta2.Definitions;
using SPMeta2.Definitions.Base;
using SPMeta2.Definitions.Webparts;
using SPMeta2.Regression.Tests.Impl.Scenarios.Base;
using SPMeta2.Standard.Services.Webparts;
using SPMeta2.Syntax.Default;
using SPMeta2.Standard.Definitions.Webparts;
using SPMeta2.Enumerations;

namespace SPMeta2.Regression.Tests.Impl.DefnitionCoverage
{
    [TestClass]
    public class WebpartDefinitionCoverageTest : SPMeta2RegresionScenarioTestBase
    {
        #region internal

        [ClassInitializeAttribute]
        public static void Init(TestContext context)
        {
            InternalInit();
        }

        [ClassCleanupAttribute]
        public static void Cleanup()
        {
            InternalCleanup();
        }

        #endregion

        #region pre-generated tests
 
		[TestMethod]
        [TestCategory("Regression.DefnitionCoverage.WebpartDefinitions")]
        public void CanDeploy_WebPartDefinition_To_AllPageTypes() 
        {
            DeployWebpartOnSupportedHosts<WebPartDefinition>();
        }
		
		[TestMethod]
        [TestCategory("Regression.DefnitionCoverage.WebpartDefinitions")]
        public void CanDeploy_PageViewerWebPartDefinition_To_AllPageTypes() 
        {
            DeployWebpartOnSupportedHosts<PageViewerWebPartDefinition>();
        }
		
		[TestMethod]
        [TestCategory("Regression.DefnitionCoverage.WebpartDefinitions")]
        public void CanDeploy_SilverlightWebPartDefinition_To_AllPageTypes() 
        {
            DeployWebpartOnSupportedHosts<SilverlightWebPartDefinition>();
        }
		
		[TestMethod]
        [TestCategory("Regression.DefnitionCoverage.WebpartDefinitions")]
        public void CanDeploy_UserCodeWebPartDefinition_To_AllPageTypes() 
        {
            DeployWebpartOnSupportedHosts<UserCodeWebPartDefinition>();
        }
		
		[TestMethod]
        [TestCategory("Regression.DefnitionCoverage.WebpartDefinitions")]
        public void CanDeploy_ClientWebPartDefinition_To_AllPageTypes() 
        {
            DeployWebpartOnSupportedHosts<ClientWebPartDefinition>();
        }
		
		[TestMethod]
        [TestCategory("Regression.DefnitionCoverage.WebpartDefinitions")]
        public void CanDeploy_ScriptEditorWebPartDefinition_To_AllPageTypes() 
        {
            DeployWebpartOnSupportedHosts<ScriptEditorWebPartDefinition>();
        }
		
		[TestMethod]
        [TestCategory("Regression.DefnitionCoverage.WebpartDefinitions")]
        public void CanDeploy_ContentEditorWebPartDefinition_To_AllPageTypes() 
        {
            DeployWebpartOnSupportedHosts<ContentEditorWebPartDefinition>();
        }
		
		[TestMethod]
        [TestCategory("Regression.DefnitionCoverage.WebpartDefinitions")]
        public void CanDeploy_ListViewWebPartDefinition_To_AllPageTypes() 
        {
            DeployWebpartOnSupportedHosts<ListViewWebPartDefinition>();
        }
		
		[TestMethod]
        [TestCategory("Regression.DefnitionCoverage.WebpartDefinitions")]
        public void CanDeploy_XsltListViewWebPartDefinition_To_AllPageTypes() 
        {
            DeployWebpartOnSupportedHosts<XsltListViewWebPartDefinition>();
        }
		
		[TestMethod]
        [TestCategory("Regression.DefnitionCoverage.WebpartDefinitions")]
        public void CanDeploy_ProjectSummaryWebPartDefinition_To_AllPageTypes() 
        {
            DeployWebpartOnSupportedHosts<ProjectSummaryWebPartDefinition>();
        }
		
		[TestMethod]
        [TestCategory("Regression.DefnitionCoverage.WebpartDefinitions")]
        public void CanDeploy_RefinementScriptWebPartDefinition_To_AllPageTypes() 
        {
            DeployWebpartOnSupportedHosts<RefinementScriptWebPartDefinition>();
        }
		
		[TestMethod]
        [TestCategory("Regression.DefnitionCoverage.WebpartDefinitions")]
        public void CanDeploy_ContactFieldControlDefinition_To_AllPageTypes() 
        {
            DeployWebpartOnSupportedHosts<ContactFieldControlDefinition>();
        }
		
		[TestMethod]
        [TestCategory("Regression.DefnitionCoverage.WebpartDefinitions")]
        public void CanDeploy_ContentBySearchWebPartDefinition_To_AllPageTypes() 
        {
            DeployWebpartOnSupportedHosts<ContentBySearchWebPartDefinition>();
        }
		
		[TestMethod]
        [TestCategory("Regression.DefnitionCoverage.WebpartDefinitions")]
        public void CanDeploy_ContentByQueryWebPartDefinition_To_AllPageTypes() 
        {
            DeployWebpartOnSupportedHosts<ContentByQueryWebPartDefinition>();
        }
		
		[TestMethod]
        [TestCategory("Regression.DefnitionCoverage.WebpartDefinitions")]
        public void CanDeploy_ResultScriptWebPartDefinition_To_AllPageTypes() 
        {
            DeployWebpartOnSupportedHosts<ResultScriptWebPartDefinition>();
        }
		
		[TestMethod]
        [TestCategory("Regression.DefnitionCoverage.WebpartDefinitions")]
        public void CanDeploy_SiteFeedWebPartDefinition_To_AllPageTypes() 
        {
            DeployWebpartOnSupportedHosts<SiteFeedWebPartDefinition>();
        }
		
		[TestMethod]
        [TestCategory("Regression.DefnitionCoverage.WebpartDefinitions")]
        public void CanDeploy_SummaryLinkWebPartDefinition_To_AllPageTypes() 
        {
            DeployWebpartOnSupportedHosts<SummaryLinkWebPartDefinition>();
        }
		       
	    #endregion

        #region utils

		private void DeployWebpartOnSupportedHosts<TWebpartType>()
            where TWebpartType : WebPartDefinitionBase
        {
            var initialDef = ModelGeneratorService.GetRandomDefinition(typeof(TWebpartType)) as TWebpartType;

            var wikiWebPartDef = initialDef.Clone<TWebpartType>();
            var webpartPageWebPartDef = initialDef.Clone<TWebpartType>();
            var publishingPageWebPartDef = initialDef.Clone<TWebpartType>();

            var listFormWebPartDef = initialDef.Clone<TWebpartType>();
            var documentLibraryFormWebPartDef = initialDef.Clone<TWebpartType>();

            var model = SPMeta2Model
                .NewWebModel(web =>
                {
                    web
                        // to web part and wiki pages
                        .AddHostList(BuiltInListDefinitions.SitePages, list =>
                        {
                            list
                                .AddRandomWebPartPage(page =>
                                {
                                    page.AddDefinitionNode(webpartPageWebPartDef);
                                })
                                .AddRandomWikiPage(page =>
                                {
                                    page.AddDefinitionNode(wikiWebPartDef);
                                });
                        })
                        // to publishing pages
                        .AddHostList(BuiltInListDefinitions.Pages, list =>
                        {
                            list
                                .AddRandomPublishingPage(page =>
                                {
                                    page.AddDefinitionNode(publishingPageWebPartDef);
                                });
                        })
                        // to list form
                         .AddRandomList(list =>
                         {
                             list.AddHostWebPartPage(new WebPartPageDefinition
                             {
                                 FileName = "AllItems.aspx",
                                 PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1,
                                 NeedOverride = false
                             }, page =>
                             {
                                 page.AddDefinitionNode(listFormWebPartDef);
                             });
                         })

                         // to document form
                         .AddRandomDocumentLibrary(list =>
                         {
                             list.AddHostFolder(BuiltInFolderDefinitions.Forms, folder =>
                             {
                                 folder.AddHostWebPartPage(new WebPartPageDefinition
                                 {
                                     FileName = "AllItems.aspx",
                                     PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1,
                                     NeedOverride = false
                                 }, page =>
                                 {
                                     page.AddDefinitionNode(documentLibraryFormWebPartDef);
                                 });
                             });
                         });
                    ;
                });

            TestModel(model);
        }

        #endregion
    }

}
