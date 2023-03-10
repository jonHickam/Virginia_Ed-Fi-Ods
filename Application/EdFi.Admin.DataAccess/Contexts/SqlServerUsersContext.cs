// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data.Entity;
using EdFi.Admin.DataAccess.Models;

namespace EdFi.Admin.DataAccess.Contexts
{
    public class SqlServerUsersContext : UsersContext
    {
        public SqlServerUsersContext(string connectionString) : base(connectionString) { }

        protected override void ApplyProviderSpecificMappings(DbModelBuilder modelBuilder)
        {
             modelBuilder.Entity<ApiClient>()
                .HasMany(t => t.ApplicationEducationOrganizations)
                .WithMany(t => t.Clients)
                .Map(
                    m =>
                    {
                        m.ToTable("ApiClientApplicationEducationOrganizations", "dbo");
                    });
        }
    }
}
