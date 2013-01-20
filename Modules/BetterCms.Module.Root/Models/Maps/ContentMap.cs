using BetterCms.Core.Models;

namespace BetterCms.Module.Root.Models.Maps
{
    public class ContentMap : EntityMapBase<Content>
    {
        public ContentMap()
            : base(RootModuleDescriptor.ModuleName)
        {
            Table("Contents");

            Map(x => x.Name).Length(MaxLength.Name).Not.Nullable();
            Map(x => x.PreviewUrl).Length(MaxLength.Url).Nullable();
            Map(x => x.Status).Not.Nullable();
            Map(x => x.PublishedByUser).Length(MaxLength.Name).Nullable();
            Map(x => x.PublishedOn).Nullable();

            References(x => x.Original).Cascade.SaveUpdate().LazyLoad();
           
            HasMany(x => x.PageContents).Inverse().Cascade.SaveUpdate().LazyLoad().Where("IsDeleted = 0");
            HasMany(x => x.ContentOptions).Inverse().Cascade.SaveUpdate().LazyLoad().Where("IsDeleted = 0");
            HasMany(x => x.History).KeyColumn("OriginalId").Cascade.None().LazyLoad().Where("IsDeleted = 0");
        }
    }
}