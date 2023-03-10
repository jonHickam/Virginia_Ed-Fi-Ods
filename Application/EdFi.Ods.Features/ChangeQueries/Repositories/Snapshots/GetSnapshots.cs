// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Common.Configuration;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Infrastructure;
using EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.Ods.Features.ChangeQueries.Resources;
using NHibernate;
using NHibernate.Transform;

namespace EdFi.Ods.Features.ChangeQueries.Repositories.Snapshots
{
    public class GetSnapshots : NHibernateRepositoryOperationBase, IGetSnapshots
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly int _defaultPageSizeLimit;

        public GetSnapshots(ISessionFactory sessionFactory, DatabaseEngine databaseEngine, IDefaultPageSizeLimitProvider defaultPageSizeLimitProvider)
            : base(sessionFactory)
        {
            _sessionFactory = sessionFactory;
            _defaultPageSizeLimit = defaultPageSizeLimitProvider.GetDefaultPageSizeLimit();
        }

        public async Task<IList<Snapshot>> GetAllAsync(IQueryParameters queryParameters)
        {
            var cmdSql = $@"
SELECT   Id, SnapshotIdentifier, SnapshotDateTime
FROM     changes.Snapshot
ORDER BY SnapshotDateTime DESC";

            using (var sessionScope = new SessionScope(_sessionFactory))
            {
                var query = sessionScope.Session.CreateSQLQuery(cmdSql)
                    .SetFirstResult(queryParameters.Offset ?? 0)
                    .SetMaxResults(queryParameters.Limit ?? _defaultPageSizeLimit)
                    .SetResultTransformer(Transformers.AliasToBean<Snapshot>());

                return await query.ListAsync<Snapshot>().ConfigureAwait(false);
            }
        }

        public async Task<long> GetTotalCountAsync()
        {
            var cmdSql = $@"
SELECT   COUNT(1)
FROM     changes.Snapshot";

            using (var sessionScope = new SessionScope(_sessionFactory))
            {
                var count = await sessionScope.Session.CreateSQLQuery(cmdSql)
                    .UniqueResultAsync().ConfigureAwait(false);

                return Convert.ToInt64(count);
            }
        }

        public async Task<Snapshot> GetByIdAsync(Guid id)
        {
            var cmdSql = $@"
SELECT   Id, SnapshotIdentifier, SnapshotDateTime
FROM     changes.Snapshot
WHERE    Id = :id";
            
            using (var sessionScope = new SessionScope(_sessionFactory))
            {
                var query = sessionScope.Session.CreateSQLQuery(cmdSql)
                    .SetGuid("id", id)
                    .SetResultTransformer(Transformers.AliasToBean<Snapshot>());

                return await query.UniqueResultAsync<Snapshot>().ConfigureAwait(false);
            }
        }
    }
}
