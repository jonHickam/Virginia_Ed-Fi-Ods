// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Security.AuthorizationStrategies.NamespaceBased
{
    /// <summary>
    /// Contains the pertinent Ed-Fi data necessary for making authorization decisions.
    /// </summary>
    public class NamespaceBasedAuthorizationContextData
    {
        // Ownership
        public string Namespace { get; set; }
    }
}
