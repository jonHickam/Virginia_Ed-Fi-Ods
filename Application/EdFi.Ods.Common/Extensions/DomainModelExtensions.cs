// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Extensions;

public static class DomainModelExtensions
{
    /// <summary>
    /// Gets the EducationOrganization base entity from the domain model.
    /// </summary>
    /// <param name="domainModel">The API domain model.</param>
    /// <returns>The EducationOrganization base entity if found; otherwise <b>null</b>.</returns>
    public static Entity EducationOrganizationBaseEntity(this DomainModel domainModel)
    {
        if (domainModel.EntityByFullName.TryGetValue(EdFiConventions.EducationOrganizationFullName, out var entity))
        {
            return entity;
        }

        return null;
    }
}
