﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
    {
        public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
        {
        }

        public override void Add(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            
            foreach (var poco in pocos)
            {
                if(string.IsNullOrEmpty(poco.Major)) {
                    exceptions.Add(new ValidationException(107, "Major can not be blank!"));
                }
                else if(poco.Major.Length < 3) {
                    exceptions.Add(new ValidationException(107, "The length of Major can not be less than three!"));
                }
                if(poco.StartDate > DateTime.Now) {
                    exceptions.Add(new ValidationException(108, "Start date can not be greater than today"));
                }
                if(poco.CompletionDate < poco.StartDate) {
                    exceptions.Add(new ValidationException(109, "Completion date can not be before the start date"));
                }

            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
