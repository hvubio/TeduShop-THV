using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IPostCategorySerice
    {
        PostCategory Add(PostCategory postCategory);
        void Update(PostCategory postCategory);
        PostCategory Delete(PostCategory postCategory);
        IEnumerable<PostCategory> GetAll();
        IEnumerable<PostCategory> GetALlByParentiD(int parentId);
        PostCategory GetById(int id);
    }
    public class PostCategoryService : IPostCategorySerice
    {
        private readonly IPostCategoryRepository _postCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            _postCategoryRepository = postCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public PostCategory Add(PostCategory postCategory)
        {
            return _postCategoryRepository.Add(postCategory);
        }

        public void Update(PostCategory postCategory)
        {
            _postCategoryRepository.Update(postCategory);
        }

        public PostCategory Delete(PostCategory postCategory)
        {
            return _postCategoryRepository.Delete(postCategory);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetALlByParentiD(int parentId)
        {
            return _postCategoryRepository.GetMulti(x=>x.ParentId == parentId && x.Status);
        }

        public PostCategory GetById(int id)
        {
            return _postCategoryRepository.GetSingleById(id);
        }
    }
}
