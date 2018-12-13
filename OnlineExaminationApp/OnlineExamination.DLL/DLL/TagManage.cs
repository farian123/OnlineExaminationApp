using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class TagManage
    {
        TagRepository _tagRepository=new TagRepository();
        public List<Tags> GetAllTagses()
        {
            return _tagRepository.GetAllTagses();
        }
        public Tags GetTagById(int? tagId)
        {
            return _tagRepository.GetTagById(tagId);
        }
    }
}
