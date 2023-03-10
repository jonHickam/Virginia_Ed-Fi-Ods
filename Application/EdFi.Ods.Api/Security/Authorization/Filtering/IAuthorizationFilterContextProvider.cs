// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Security.Authorization;

namespace EdFi.Ods.Api.Security.Authorization.Filtering
{
    /// <summary>
    /// Defines a method for storing and retrieving parameterized filters to and from context storage.
    /// </summary>
    public interface IAuthorizationFilterContextProvider
    {
        /// <summary>
        /// Sets parameterized filters to the current context.
        /// </summary>
        /// <param name="filters">A list of authorization filters.</param>
        void SetFilterContext(IReadOnlyList<AuthorizationStrategyFiltering> filters);

        /// <summary>
        /// Gets parameterized authorization strategy-based filtering from the current context, or an empty list if none have been set. 
        /// </summary>
        /// <returns>The list of strategy-based filtering.</returns>
        IReadOnlyList<AuthorizationStrategyFiltering> GetFilterContext();
    }
}
