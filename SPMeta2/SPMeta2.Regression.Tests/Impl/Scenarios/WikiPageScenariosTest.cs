﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Containers;
using SPMeta2.Containers.Standard;
using SPMeta2.Definitions;
using SPMeta2.Definitions.Fields;
using SPMeta2.Enumerations;
using SPMeta2.Models;
using SPMeta2.Regression.Tests.Definitions;
using SPMeta2.Regression.Tests.Impl.Scenarios.Base;
using SPMeta2.Regression.Tests.Prototypes;
using SPMeta2.Standard.Definitions;
using SPMeta2.Syntax.Default;
using SPMeta2.Validation.Validators.Relationships;

namespace SPMeta2.Regression.Tests.Impl.Scenarios
{
    [TestClass]
    public class WikiPageScenariosTest : SPMeta2RegresionScenarioTestBase
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

        #region default

        [TestMethod]
        [TestCategory("Regression.Scenarios.WikiPages")]
        public void CanDeploy_WikiPage()
        {
            WithSitePagesList(sitePages =>
            {
                sitePages.AddRandomWikiPage();
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.WikiPages")]
        public void CanDeploy_WikiPageToFolder()
        {
            WithSitePagesList(sitePages =>
            {
                sitePages.AddRandomFolder(folder =>
                {
                    folder.AddRandomWikiPage();
                });
            });
        }

        [TestMethod]
        [TestCategory("Regression.Scenarios.WikiPages.Values")]
        public void CanDeploy_Default_WikiPage_With_RequiredFieldValues()
        {
            var requiredText = RItemValues.GetRequiredTextField(ModelGeneratorService);

            var text1 = RItemValues.GetRandomTextField(ModelGeneratorService);
            var text2 = RItemValues.GetRandomTextField(ModelGeneratorService);


            var contentTypeDef = ModelGeneratorService.GetRandomDefinition<ContentTypeDefinition>(def =>
            {
                def.ParentContentTypeId = BuiltInContentTypeId.Item;
            });

            var itemDef = ModelGeneratorService.GetRandomDefinition<WikiPageDefinition>(def =>
            {
                def.ContentTypeName = contentTypeDef.Name;

                def.DefaultValues.Add(new FieldValue()
                {
                    FieldName = requiredText.InternalName,
                    Value = Rnd.String()
                });

                def.Values.Add(new FieldValue()
                {
                    FieldName = text1.InternalName,
                    Value = Rnd.String()
                });

                def.Values.Add(new FieldValue()
                {
                    FieldName = text2.InternalName,
                    Value = Rnd.String()
                });
            });

            var listDef = ModelGeneratorService.GetRandomDefinition<ListDefinition>(def =>
            {
                def.ContentTypesEnabled = true;
                def.TemplateType = BuiltInListTemplateTypeId.DocumentLibrary;
            });

            var siteModel = SPMeta2Model.NewSiteModel(site =>
            {
                site.AddField(requiredText);
                site.AddField(text1);
                site.AddField(text2);

                site.AddContentType(contentTypeDef, contentType =>
                {
                    contentType.AddContentTypeFieldLink(requiredText);
                    contentType.AddContentTypeFieldLink(text1);
                    contentType.AddContentTypeFieldLink(text2);
                });

            });

            var webModel = SPMeta2Model.NewWebModel(web =>
            {
                web.AddList(BuiltInListDefinitions.SitePages.Inherit(d =>
                {
                    d.ContentTypesEnabled = true;
                }), list =>
                {
                    list.AddContentTypeLink(contentTypeDef);
                    list.AddWikiPage(itemDef);
                });
            });

            TestModel(siteModel, webModel);
        }


        [TestMethod]
        [TestCategory("Regression.Scenarios.WikiPages.Values")]
        public void CanDeploy_Default_WikiPage_With_ContentType_ByName()
        {
            var webFeature = BuiltInWebFeatures.WikiPageHomePage.Inherit(f => f.Enable());

            var contentTypeDef = ModelGeneratorService.GetRandomDefinition<ContentTypeDefinition>(def =>
            {
                def.ParentContentTypeId = BuiltInContentTypeId.WikiDocument;
            });

            var itemDef = ModelGeneratorService.GetRandomDefinition<WikiPageDefinition>(def =>
            {
                def.ContentTypeName = contentTypeDef.Name;
            });

            var siteModel = SPMeta2Model.NewSiteModel(site =>
            {
                site.AddContentType(contentTypeDef);
            });

            var webModel = SPMeta2Model.NewWebModel(web =>
            {
                web.AddFeature(webFeature);

                web.AddList(BuiltInListDefinitions.SitePages.Inherit(d =>
                {
                    d.ContentTypesEnabled = true;
                }), list =>
                {
                    list.AddContentTypeLink(contentTypeDef);
                    list.AddWikiPage(itemDef);
                });
            });

            TestModel(siteModel, webModel);
        }

        #endregion

        #region utils

        private void WithSitePagesList(Action<ListModelNode> pagesList)
        {
            var webModel = SPMeta2Model
               .NewWebModel(web =>
               {
                   web
                       .AddWebFeature(BuiltInWebFeatures.WikiPageHomePage.Inherit(def =>
                       {
                           def.Enable = true;
                       }))
                       .AddHostList(BuiltInListDefinitions.SitePages, list =>
                       {
                           pagesList(list);
                       });
               });

            TestModel(webModel);
        }

        #endregion

    }
}
