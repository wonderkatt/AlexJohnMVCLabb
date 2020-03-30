using AutoMapper;
namespace BloodBowlTeamManager.Models
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Team, TeamOverviewResponse>().ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.TeamName))
                                      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                                      .ForMember(dest => dest.Coach, opt => opt.MapFrom(src => src.Coach.Id))
                                      .ForMember(dest => dest.Race, opt => opt.MapFrom(src => src.Race.RaceName))
                                      .ForMember(dest => dest.Teamvalue, opt => opt.MapFrom(src => src.Teamvalue));

            CreateMap<Player, TeamPlayerDetailsResponse>().ForMember(dest => dest.PlayerName, opt => opt.MapFrom(src => src.PlayerName))
                                      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                                      .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                                      .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                                      .ForMember(dest => dest.MovementValue, opt => opt.MapFrom(src => src.MovementValue))
                                      .ForMember(dest => dest.StrengthValue, opt => opt.MapFrom(src => src.StrengthValue))
                                      .ForMember(dest => dest.AgilityValue, opt => opt.MapFrom(src => src.AgilityValue))
                                      .ForMember(dest => dest.ArmourValue, opt => opt.MapFrom(src => src.ArmourValue))
                                      .ForMember(dest => dest.MissNextGame, opt => opt.MapFrom(src => src.MissNextGame))
                                      .ForMember(dest => dest.AgilitySkills, opt => opt.MapFrom(src => src.AgilitySkills))
                                      .ForMember(dest => dest.StrengthSkills, opt => opt.MapFrom(src => src.StrengthSkills))
                                      .ForMember(dest => dest.GeneralSkills, opt => opt.MapFrom(src => src.GeneralSkills))
                                      .ForMember(dest => dest.PassingSkills, opt => opt.MapFrom(src => src.PassingSkills))
                                      .ForMember(dest => dest.Mutations, opt => opt.MapFrom(src => src.Mutations))
                                      .ForMember(dest => dest.SpecialSkills, opt => opt.MapFrom(src => src.SpecialSkills))
                                      .ForMember(dest => dest.Touchdowns, opt => opt.MapFrom(src => src.Touchdowns))
                                      .ForMember(dest => dest.Casualties, opt => opt.MapFrom(src => src.Casualties))
                                      .ForMember(dest => dest.Completions, opt => opt.MapFrom(src => src.Completions))
                                      .ForMember(dest => dest.Casualties, opt => opt.MapFrom(src => src.Casualties))
                                      .ForMember(dest => dest.MVP, opt => opt.MapFrom(src => src.MVP))
                                      .ForMember(dest => dest.SPP, opt => opt.MapFrom(src => src.SPP))
                                      .ForMember(dest => dest.PlayedGames, opt => opt.MapFrom(src => src.PlayedGames))
                                      .ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.Cost));

            CreateMap<Team, TeamDTO>().ReverseMap();

            CreateMap<Race, RaceDTO>().ReverseMap();

            CreateMap<Player, PlayerDTO>().ReverseMap();

            CreateMap<Coach, CoachDTO>().ReverseMap();

            CreateMap<GeneralSkill, GeneralSkillDTO>().ReverseMap();
         
            CreateMap<AgilitySkill, AgilitySkillDTO>().ReverseMap();

            CreateMap<StrengthSkill, StrengthSkillDTO>().ReverseMap();

            CreateMap<PassSkill, PassSkillDTO>().ReverseMap();

            CreateMap<Mutation, MutationDTO>().ReverseMap();

            CreateMap<SpecialSkill, SpecialSkillDTO>().ReverseMap();

            CreateMap<Player, TeamPlayersOverviewResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PlayerName, opt => opt.MapFrom(src => src.PlayerName))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position));

        }
    }
}
