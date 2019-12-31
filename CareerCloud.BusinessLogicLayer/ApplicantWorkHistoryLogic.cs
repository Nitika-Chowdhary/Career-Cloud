using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantWorkHistorysLogic : BaseLogic<ApplicantWorkHistorysPoco>
    {
        public ApplicantWorkHistorysLogic(IDataRepository<ApplicantWorkHistorysPoco> repository) : base(repository)
        {
        }

        public override void Add(ApplicantWorkHistorysPoco[] pocos)
        {
            Verify(pocos);
            foreach (ApplicantWorkHistorysPoco poco in pocos)
            {
                
            }
            base.Add(pocos);
        }

        public override void Update(ApplicantWorkHistorysPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantWorkHistorysPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            
            foreach (var poco in pocos)
            {
                

            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
