//=====================================================================================================================================================
// Bing Ads .NET SDK ver. 11.12
// 
// Copyright (c) Microsoft Corporation
// 
// All rights reserved. 
// 
// MS-PL License
// 
// This license governs use of the accompanying software. If you use the software, you accept this license. 
//  If you do not accept the license, do not use the software.
// 
// 1. Definitions
// 
// The terms reproduce, reproduction, derivative works, and distribution have the same meaning here as under U.S. copyright law. 
//  A contribution is the original software, or any additions or changes to the software. 
//  A contributor is any person that distributes its contribution under this license. 
//  Licensed patents  are a contributor's patent claims that read directly on its contribution.
// 
// 2. Grant of Rights
// 
// (A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, 
//  each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, 
//  prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.
// 
// (B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, 
//  each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, 
//  sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.
// 
// 3. Conditions and Limitations
// 
// (A) No Trademark License - This license does not grant you rights to use any contributors' name, logo, or trademarks.
// 
// (B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, 
//  your patent license from such contributor to the software ends automatically.
// 
// (C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, 
//  and attribution notices that are present in the software.
// 
// (D) If you distribute any portion of the software in source code form, 
//  you may do so only under this license by including a complete copy of this license with your distribution. 
//  If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.
// 
// (E) The software is licensed *as-is.* You bear the risk of using it. The contributors give no express warranties, guarantees or conditions.
//  You may have additional consumer rights under your local laws which this license cannot change. 
//  To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, 
//  fitness for a particular purpose and non-infringement.
//=====================================================================================================================================================

using System;
using Microsoft.BingAds.V12.CampaignManagement;
using Microsoft.BingAds.V12.Internal.Bulk;
using Microsoft.BingAds.V12.Internal.Bulk.Entities;
using Microsoft.BingAds.V12.Internal.Bulk.Mappings;

namespace Microsoft.BingAds.V12.Bulk.Entities
{
    /// <summary>
    /// <para>
    /// Represents an Ad Group Negative In Market Audience Association that can be read or written in a bulk file. 
    /// This class exposes the <see cref="NegativeAdGroupCriterion"/> property that can be read and written as fields of the Ad Group Negative In Market Audience Association record in a bulk file. 
    /// </para>
    /// <para>For more information, see <see href="https://go.microsoft.com/fwlink/?linkid=846127">Ad Group Negative In Market Audience Association</see> </para>
    /// </summary>
    /// <seealso cref="BulkServiceManager"/>
    /// <seealso cref="BulkOperation{TStatus}"/>
    /// <seealso cref="BulkFileReader"/>
    /// <seealso cref="BulkFileWriter"/>
    public class BulkAdGroupNegativeInMarketAudienceAssociation : SingleRecordBulkEntity
    {
        /// <summary>
        /// Defines an Negative Ad Group Criterion.
        /// </summary>
        public NegativeAdGroupCriterion NegativeAdGroupCriterion { get; set; }

        /// <summary>
        /// The name of the campaign that contains the ad group.
        /// Corresponds to the 'Campaign' field in the bulk file. 
        /// </summary>
        public string CampaignName { get; set; }

        /// <summary>
        /// The <see href="https://go.microsoft.com/fwlink/?linkid=846127">Ad Group</see> that is associated with the audience.
        /// Corresponds to the 'Ad Group' field in the bulk file.
        /// </summary>
        public string AdGroupName { get; set; }

        /// <summary>
        /// The name of the In Market Audience
        /// Corresponds to the "Audience" field in the bulk file.
        /// </summary>
        public string InMarketAudienceName { get; set; }

        private static readonly IBulkMapping<BulkAdGroupNegativeInMarketAudienceAssociation>[] Mappings =
        {
            new SimpleBulkMapping<BulkAdGroupNegativeInMarketAudienceAssociation>(StringTable.Status,
                c => c.NegativeAdGroupCriterion.Status.ToBulkString(),
                (v, c) => c.NegativeAdGroupCriterion.Status = v.ParseOptional<AdGroupCriterionStatus>()
            ),

            new SimpleBulkMapping<BulkAdGroupNegativeInMarketAudienceAssociation>(StringTable.Id,
                c => c.NegativeAdGroupCriterion.Id.ToBulkString(),
                (v, c) => c.NegativeAdGroupCriterion.Id = v.ParseOptional<long>()
            ),

            new SimpleBulkMapping<BulkAdGroupNegativeInMarketAudienceAssociation>(StringTable.ParentId,
                c => c.NegativeAdGroupCriterion.AdGroupId.ToBulkString(true),
                (v, c) => c.NegativeAdGroupCriterion.AdGroupId = v.Parse<long>()
            ),

            new SimpleBulkMapping<BulkAdGroupNegativeInMarketAudienceAssociation>(StringTable.Campaign,
                c => c.CampaignName,
                (v, c) => c.CampaignName = v
            ),

            new SimpleBulkMapping<BulkAdGroupNegativeInMarketAudienceAssociation>(StringTable.AdGroup,
                c => c.AdGroupName,
                (v, c) => c.AdGroupName = v
            ),

            new SimpleBulkMapping<BulkAdGroupNegativeInMarketAudienceAssociation>(StringTable.Audience,
                c => c.InMarketAudienceName,
                (v, c) => c.InMarketAudienceName = v
            ),

            new SimpleBulkMapping<BulkAdGroupNegativeInMarketAudienceAssociation>(StringTable.AudienceId,
                c =>
                {
                    var audienceCriterion = c.NegativeAdGroupCriterion?.Criterion as AudienceCriterion;

                    return audienceCriterion != null ? audienceCriterion.AudienceId.ToBulkString() : null;
                },
                (v, c) =>
                {
                    var audienceCriterion = c.NegativeAdGroupCriterion?.Criterion as AudienceCriterion;

                    if (audienceCriterion != null)
                    {
                        audienceCriterion.AudienceId = v.ParseOptional<long>();
                    }
                }
            ),
        };

        internal override void ProcessMappingsToRowValues(RowValues values, bool excludeReadonlyData)
        {
            ValidatePropertyNotNull(NegativeAdGroupCriterion, typeof(NegativeAdGroupCriterion).Name);

            this.ConvertToValues(values, Mappings);
        }

        internal override void ProcessMappingsFromRowValues(RowValues values)
        {
            NegativeAdGroupCriterion = new NegativeAdGroupCriterion
            {
                Criterion = new AudienceCriterion()
                {
                    Type = typeof(AudienceCriterion).Name,
                },
                Type = typeof(NegativeAdGroupCriterion).Name
            };

            values.ConvertToEntity(this, Mappings);
        }
    }
}
