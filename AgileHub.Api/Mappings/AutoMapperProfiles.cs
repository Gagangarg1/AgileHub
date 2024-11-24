using AgileHub.Api.Models.Domain;
using AgileHub.Api.Models.Domain.PokerPlanning;
using AgileHub.Api.Models.Domain.SprintRetro;
using AgileHub.Api.Models.DTO;
using AgileHub.Api.Models.DTO.PokerPlanning;
using AgileHub.Api.Models.DTO.SprintRetro;
using AutoMapper;

namespace AgileHub.Api.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<EstimationSystem, EstimationSystemDto>().ReverseMap();

            CreateMap<Avatar, AvatarDto>().ReverseMap();
            CreateMap<Avatar, CreateAvatarDto>().ReverseMap();
            CreateMap<Avatar, UpdateAvatarDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, UserInfoDto>().ReverseMap();
            CreateMap<UserDto, UserInfoDto>().ReverseMap();

            CreateMap<Story, StoryDto>().ReverseMap();
            CreateMap<Story, CreateStoryDto>().ReverseMap();
            CreateMap<Story, UpdateStoryDto>().ReverseMap();

            CreateMap<Vote, VoteDto>().ReverseMap();
            CreateMap<Vote, CreateVoteDto>().ReverseMap();
            CreateMap<Vote, UpdateVoteDto>().ReverseMap();

            CreateMap<PlanningRoom, PlanningRoomDto>().ReverseMap();
            CreateMap<PlanningRoom, CreatePlanningRoomDto>().ReverseMap();
            CreateMap<PlanningRoom, UpdatePlanningRoomDto>().ReverseMap();

            CreateMap<RetroBoard, RetroBoardDto>().ReverseMap();
            CreateMap<RetroBoard, CreateRetroBoardDto>().ReverseMap();
            CreateMap<RetroBoard, UpdateRetroBoardDto>().ReverseMap();

            CreateMap<BoardColumn, BoardColumnDto>().ReverseMap();
            CreateMap<BoardColumn, CreateBoardColumnDto>().ReverseMap();
            CreateMap<BoardColumn, UpdateBoardColumnDto>().ReverseMap();

            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();

            CreateMap<Note, NoteDto>().ReverseMap();
            CreateMap<Note, CreateNoteDto>().ReverseMap();
            CreateMap<Note, UpdateNoteDto>().ReverseMap();
        }
    }
}
