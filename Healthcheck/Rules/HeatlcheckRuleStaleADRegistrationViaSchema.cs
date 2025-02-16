﻿using PingCastle.Graph.Reporting;
//
// Copyright (c) Ping Castle. All rights reserved.
// https://www.pingcastle.com
//
// Licensed under the Non-Profit OSL. See LICENSE file in the project root for full license information.
//
using PingCastle.Rules;
using System.Collections.Generic;
using System.Diagnostics;

namespace PingCastle.Healthcheck.Rules
{
    [RuleModel("S-ADRegistrationSchema", RiskRuleCategory.StaleObjects, RiskModelCategory.Provisioning)]
    [RuleComputation(RuleComputationType.TriggerOnPresence, 10)]
    [RuleMaturityLevel(3)]
    [RuleMitreAttackMitigation(MitreAttackMitigation.UserAccountManagement)]
    [RuleIntroducedIn(2,9,3)]
    public class HeatlcheckRuleStaleADRegistrationViaSchema : RuleBase<HealthcheckData>
    {
        protected override int? AnalyzeDataNew(HealthcheckData healthcheckData)
        {
            if (healthcheckData.SchemaClassVulnerable != null)
            {
                foreach(var Class in healthcheckData.SchemaClassVulnerable)
                {
                    AddRawDetail(Class.Class, Class.Vulnerability);
                }
            }
            return null;
        }
    }
}
