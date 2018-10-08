﻿using Nerdable.NotesApi.Services.TagService.Models;
using Nerdable.NotesApi.Services.UserService.Models;
using System;
using System.Collections.Generic;

namespace Nerdable.NotesApi.Services.NoteService.Models
{
    public class NoteDetail : NoteBase
    {
        public int NoteId { get; set; }
        public UserDetail CreatedByUser { get; set; }
        public ICollection<TagSummary> Tags { get; set; }
    }
}
