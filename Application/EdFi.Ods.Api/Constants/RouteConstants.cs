// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.Constants
{
    public static class RouteConstants
    {
        public static string DataManagementRoutePrefix
        {
            get => $"data/v{ApiVersionConstants.Ods}";
        }

        public static string Dependencies
        {
            get => "AggregateDependencies";
        }

        public static string SchoolYearFromRoute
        {
            get => @"{schoolYearFromRoute:regex(^\d{{4}}$)}/";
        }

        public static string InstanceIdFromRoute
        {
            get => @"{instanceIdFromRoute:regex(^[[A-Za-z0-9-]]+$)}/";
        }

        public static string InstanceIdFromRouteForFilter
        {
            get => @"{instanceIdFromRoute:regex(^[A-Za-z0-9-]+$)}/";
        }
    }
}
