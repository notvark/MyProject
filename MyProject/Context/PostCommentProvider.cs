using Microsoft.EntityFrameworkCore;
using MyProject.Model;

namespace MyProject.Context
{
    public class PostCommentProvider
    {

        private readonly DatabaseContext _context;

        public PostCommentProvider(DatabaseContext context)
        {
            _context = context;
        }

    }
}
