﻿// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using EdFi.Ods.Api.Pipelines;
using EdFi.Ods.Pipelines;

namespace EdFi.Ods.Api.ChangeQueries.Pipelines.GetDeletedResource
{
    public class GetDeletedResourceResult: PipelineResultBase, IHasResourceChangeDetails
    {
        public bool ResourceWasCreated { get; set; }
        public bool ResourceWasUpdated { get; set; }
        public bool ResourceWasDeleted { get; set; }
    }
}