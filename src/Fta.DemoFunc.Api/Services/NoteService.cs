using Fta.DemoFunc.Api.Dtos;
using Fta.DemoFunc.Api.Entities;
using Fta.DemoFunc.Api.Interfaces;
using Fta.DemoFunc.Api.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fta.DemoFunc.Api.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ILoggerAdapter<NoteService> _logger;

        public NoteService(INoteRepository noteRepository, IDateTimeProvider dateTimeProvider, ILoggerAdapter<NoteService> logger)
        {
            _noteRepository = noteRepository;
            _dateTimeProvider = dateTimeProvider;
            _logger = logger;
        }

        public async Task<NoteDto> CreateNoteAsync(CreateNoteOptions createNoteOptions, CancellationToken ct)
        {
            if (string.IsNullOrEmpty(createNoteOptions.Title) || string.IsNullOrEmpty(createNoteOptions.Body))
            {
                _logger.LogError("Title or body of note cannot be empty. Returning null by default.");

                return null;
            }

            var newNote = await _noteRepository.CreateAsync(new Note
            {
                Id = Guid.NewGuid().ToString(),
                Title = createNoteOptions.Title,
                Body = createNoteOptions.Body,
                CreatedAt = _dateTimeProvider.UtcNow,
                LastUpdatedOn = _dateTimeProvider.UtcNow
            }, ct);

            return new NoteDto
            {
                Id = newNote.Id,
                Title = newNote.Title,
                LastUpdatedOn = newNote.LastUpdatedOn,
                Body = newNote.Body
            };
        }
    }
}
