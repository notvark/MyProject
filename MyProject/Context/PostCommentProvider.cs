﻿using Microsoft.EntityFrameworkCore;
using MyProject.Model;
using System.Runtime.CompilerServices;

namespace MyProject.Context
{
    public class PostCommentProvider
    {

        private readonly DatabaseContext _context;

        public PostCommentProvider(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<PostComment>> GetCommentByPostAsync(Post post)
        {
            if (post == null)
            {
                return new List<PostComment>();
            }

            return await _context.PostComments
                .Where(postcomment => postcomment.Post.Id == post.Id)
                .ToListAsync();
        }

        public async Task<List<PostComment>> GetCommentByUserAsync(User user)
        {
            if (user == null)
            {
                return new List<PostComment>();
            }

            return await _context.PostComments
                .Where(postcomment => postcomment.User.Id == user.Id)
                .ToListAsync();
        }

        public async Task AddPostCommentAsync(PostComment PostComment)
        {
            _context.PostComments.Add(PostComment);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostCommentAsync(PostComment PostComment)
        {
            _context.PostComments.Remove(PostComment);
            await _context.SaveChangesAsync();
        }

        public int CountCommentsForPostAsync(Post post)
        {
            var comment = _context.PostComments
                .Where(postcomment => postcomment.Post.Id == post.Id)
                .Count();

            return comment;
        } //Testing Function 30/10/24

    }
}
