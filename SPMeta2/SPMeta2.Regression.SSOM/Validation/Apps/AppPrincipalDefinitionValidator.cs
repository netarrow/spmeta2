﻿using System;
using Microsoft.SharePoint;
using SPMeta2.Definitions;
using SPMeta2.Definitions.Base;
using SPMeta2.Regression.Assertion;
using SPMeta2.SSOM.ModelHandlers;
using SPMeta2.SSOM.ModelHosts;
using SPMeta2.Syntax.Default;
using SPMeta2.Utils;

namespace SPMeta2.Regression.SSOM.Validation.Apps
{
    public class AppPrincipalDefinitionValidator : AppPrincipalModelHandler
    {
        public override void DeployModel(object modelHost, DefinitionBase model)
        {
            var webHost = modelHost.WithAssertAndCast<WebModelHost>("modelHost", value => value.RequireNotNull());
            var definition = model.WithAssertAndCast<AppPrincipalDefinition>("model", value => value.RequireNotNull());

            var spObject = FindExistingAppPrincipal(webHost, definition);

            var assert = ServiceFactory.AssertService
                .NewAssert(definition, spObject)
                .ShouldNotBeNull(spObject);

            assert
                .ShouldBeEqual(m => m.Title, o => o.DisplayName);
        }
    }

}
