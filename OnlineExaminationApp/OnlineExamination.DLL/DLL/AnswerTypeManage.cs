using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamination.Models.Models;
using OnlineExamination.Repositories.Repository;

namespace OnlineExamination.DLL.DLL
{
    public class AnswerTypeManage
    {
        AnswerTypeRepository _answerTypeRepository=new AnswerTypeRepository();
        public List<AnswerType> GetAllAnswerType()
        {
            return _answerTypeRepository.GetAllAnswerType();
            //return db.Batches.Include(x=>x.Course).Include(x=>x.Organization).ToList();
        }

        public AnswerType GetAllAnswerTypeById(int answerTypeId)
        {
            return _answerTypeRepository.GetAllAnswerTypeById(answerTypeId);
        }
    }
}
