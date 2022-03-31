﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.Common.Specifications;
using EdFi.Ods.Api.Security.Authorization;

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships
{
    public class RelationshipsWithEdOrgsOnlyAuthorizationStrategy<TContextData>
        : RelationshipsAuthorizationStrategyBase<TContextData>
        where TContextData : RelationshipsAuthorizationContextData, new()
    {
        protected override void BuildAuthorizationSegments(
            AuthorizationBuilder<TContextData> authorizationBuilder,
            string[] authorizationContextPropertyNames)
        {
            authorizationBuilder.ClaimsMustBeAssociatedWith(
                authorizationContextPropertyNames
                   .Where(EducationOrganizationEntitySpecification.IsEducationOrganizationIdentifier)
                   .ToArray());
        }
    }
}
