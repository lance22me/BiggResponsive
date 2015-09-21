using System.Collections.Generic;
using BiggResponsive.Domain.Interfaces;
using BiggResponsive.Domain.Models;
using BiggResponsive.Domain.Utilities;

namespace BiggResponsive.Service
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository repository;

        public MemberService(IMemberRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Member> GetAll()
        {
            return this.repository.GetAll();
        }

        public IEnumerable<Member> GetByTag(string tag)
        {
            Guard.ParameterNotNullOrEmpty(tag, "tag");

            return this.repository.GetByTag(tag);
        }
    }
}
