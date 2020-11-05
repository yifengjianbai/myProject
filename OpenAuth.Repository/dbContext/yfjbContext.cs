using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OpenAuth.Repository.dbContext
{
    public partial class yfjbContext : DbContext
    {
        public yfjbContext()
        {
        }

        public yfjbContext(DbContextOptions<yfjbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Categorytype> Categorytype { get; set; }
        public virtual DbSet<Dataprivilegerule> Dataprivilegerule { get; set; }
        public virtual DbSet<Flowinstance> Flowinstance { get; set; }
        public virtual DbSet<Flowinstanceoperationhistory> Flowinstanceoperationhistory { get; set; }
        public virtual DbSet<Flowinstancetransitionhistory> Flowinstancetransitionhistory { get; set; }
        public virtual DbSet<Flowscheme> Flowscheme { get; set; }
        public virtual DbSet<Form> Form { get; set; }
        public virtual DbSet<Frmleavereq> Frmleavereq { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Moduleelement> Moduleelement { get; set; }
        public virtual DbSet<Org> Org { get; set; }
        public virtual DbSet<Relevance> Relevance { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<Syslog> Syslog { get; set; }
        public virtual DbSet<Sysmessage> Sysmessage { get; set; }
        public virtual DbSet<TableDiary> TableDiary { get; set; }
        public virtual DbSet<Ticksanalysis> Ticksanalysis { get; set; }
        public virtual DbSet<Uploadfile> Uploadfile { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Wmsinboundorderdtbl> Wmsinboundorderdtbl { get; set; }
        public virtual DbSet<Wmsinboundordertbl> Wmsinboundordertbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=139.9.228.230;uid=root;pwd=900306;database=yfjb", x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("application");

                entity.HasComment("应用");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("AppId")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AppSecret)
                    .HasColumnType("varchar(255)")
                    .HasComment("应用密钥")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("date")
                    .HasComment("创建日期");

                entity.Property(e => e.CreateUser)
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    .HasComment("应用描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Disable).HasComment("是否可用");

                entity.Property(e => e.Icon)
                    .HasColumnType("varchar(255)")
                    .HasComment("应用图标")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("应用名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.HasComment("分类表，也可用作数据字典。表示一个全集，比如：男、女、未知。关联的分类类型表示按什么进行的分类，如：按照性别对人类对象集");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUserId)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateUserName)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasComment("创建人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DtCode)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("分类标识")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DtValue)
                    .HasColumnType("varchar(50)")
                    .HasComment("通常与分类标识一致，但万一有不一样的情况呢？")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("' '")
                    .HasComment("分类名称或描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SortNo).HasComment("排序号");

                entity.Property(e => e.TypeId)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.UpdateUserId)
                    .HasColumnType("varchar(50)")
                    .HasComment("最后更新人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdateUserName)
                    .HasColumnType("varchar(200)")
                    .HasComment("最后更新人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Categorytype>(entity =>
            {
                entity.ToTable("categorytype");

                entity.HasComment("分类类型");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("分类表ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Dataprivilegerule>(entity =>
            {
                entity.ToTable("dataprivilegerule");

                entity.HasComment("系统授权规制表");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("数据ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUserId)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateUserName)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasComment("创建人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("' '")
                    .HasComment("权限描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Enable)
                    .IsRequired()
                    .HasDefaultValueSql("'1'")
                    .HasComment("是否可用");

                entity.Property(e => e.PrivilegeRules)
                    .IsRequired()
                    .HasColumnType("varchar(1000)")
                    .HasDefaultValueSql("' '")
                    .HasComment("权限规则")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SortNo).HasComment("排序号");

                entity.Property(e => e.SourceCode)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("资源标识（模块编号）")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SubSourceCode)
                    .HasColumnType("varchar(50)")
                    .HasComment("二级资源标识")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.UpdateUserId)
                    .HasColumnType("varchar(50)")
                    .HasComment("最后更新人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdateUserName)
                    .HasColumnType("varchar(200)")
                    .HasComment("最后更新人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Flowinstance>(entity =>
            {
                entity.ToTable("flowinstance");

                entity.HasComment("工作流流程实例表");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("主键Id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ActivityId)
                    .HasColumnType("varchar(50)")
                    .HasComment("当前节点ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ActivityName)
                    .HasColumnType("varchar(200)")
                    .HasComment("当前节点名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ActivityType).HasComment("当前节点类型（0会签节点）");

                entity.Property(e => e.Code)
                    .HasColumnType("varchar(200)")
                    .HasComment("实例编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUserId)
                    .HasColumnType("varchar(50)")
                    .HasComment("创建用户主键")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateUserName)
                    .HasColumnType("varchar(50)")
                    .HasComment("创建用户")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CustomName)
                    .HasColumnType("varchar(200)")
                    .HasComment("自定义名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DbName)
                    .HasColumnType("varchar(50)")
                    .HasComment("数据库名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasComment("实例备注")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Disabled).HasComment("有效标志");

                entity.Property(e => e.FlowLevel).HasComment("等级");

                entity.Property(e => e.FrmContentData)
                    .HasColumnType("longtext")
                    .HasComment("表单中的控件属性描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FrmContentParse)
                    .HasColumnType("longtext")
                    .HasComment("表单控件位置模板")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FrmData)
                    .HasColumnType("longtext")
                    .HasComment("表单数据")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FrmId)
                    .HasColumnType("varchar(50)")
                    .HasComment("表单ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FrmType).HasComment("表单类型");

                entity.Property(e => e.InstanceSchemeId)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("流程实例模板Id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsFinish).HasComment("是否完成");

                entity.Property(e => e.MakerList)
                    .HasColumnType("text")
                    .HasComment("执行人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrgId)
                    .HasColumnType("varchar(50)")
                    .HasComment("所属部门")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PreviousId)
                    .HasColumnType("varchar(50)")
                    .HasComment("前一个ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SchemeContent)
                    .HasColumnType("longtext")
                    .HasComment("流程模板内容")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SchemeId)
                    .HasColumnType("varchar(50)")
                    .HasComment("流程模板ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SchemeType)
                    .HasColumnType("varchar(50)")
                    .HasComment("流程类型")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Flowinstanceoperationhistory>(entity =>
            {
                entity.ToTable("flowinstanceoperationhistory");

                entity.HasComment("工作流实例操作记录");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("主键Id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Content)
                    .HasColumnType("varchar(200)")
                    .HasComment("操作内容")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUserId)
                    .HasColumnType("varchar(50)")
                    .HasComment("创建用户主键")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateUserName)
                    .HasColumnType("varchar(50)")
                    .HasComment("创建用户")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InstanceId)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("实例进程Id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Flowinstancetransitionhistory>(entity =>
            {
                entity.ToTable("flowinstancetransitionhistory");

                entity.HasComment("工作流实例流转历史记录");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("主键Id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasComment("转化时间");

                entity.Property(e => e.CreateUserId)
                    .HasColumnType("varchar(50)")
                    .HasComment("操作人Id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateUserName)
                    .HasColumnType("varchar(50)")
                    .HasComment("操作人名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FromNodeId)
                    .HasColumnType("varchar(50)")
                    .HasComment("开始节点Id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FromNodeName)
                    .HasColumnType("varchar(200)")
                    .HasComment("开始节点名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FromNodeType).HasComment("开始节点类型");

                entity.Property(e => e.InstanceId)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("实例Id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsFinish).HasComment("是否结束");

                entity.Property(e => e.ToNodeId)
                    .HasColumnType("varchar(50)")
                    .HasComment("结束节点Id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ToNodeName)
                    .HasColumnType("varchar(200)")
                    .HasComment("结束节点名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ToNodeType).HasComment("结束节点类型");

                entity.Property(e => e.TransitionSate).HasComment("转化状态");
            });

            modelBuilder.Entity<Flowscheme>(entity =>
            {
                entity.ToTable("flowscheme");

                entity.HasComment("工作流模板信息表");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("主键Id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AuthorizeType).HasComment("模板权限类型：0完全公开,1指定部门/人员");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUserId)
                    .HasColumnType("varchar(50)")
                    .HasComment("创建用户主键")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateUserName)
                    .HasColumnType("varchar(50)")
                    .HasComment("创建用户")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DeleteMark).HasComment("删除标记");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Disabled).HasComment("有效");

                entity.Property(e => e.FrmId)
                    .HasColumnType("varchar(50)")
                    .HasComment("表单ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FrmType).HasComment("表单类型");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnType("varchar(50)")
                    .HasComment("修改用户主键")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifyUserName)
                    .HasColumnType("varchar(50)")
                    .HasComment("修改用户")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrgId)
                    .HasColumnType("varchar(50)")
                    .HasComment("所属部门")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SchemeCanUser)
                    .HasColumnType("longtext")
                    .HasComment("流程模板使用者")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SchemeCode)
                    .HasColumnType("varchar(50)")
                    .HasComment("流程编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SchemeContent)
                    .HasColumnType("longtext")
                    .HasComment("流程内容")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SchemeName)
                    .HasColumnType("varchar(200)")
                    .HasComment("流程名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SchemeType)
                    .HasColumnType("varchar(50)")
                    .HasComment("流程分类")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SchemeVersion)
                    .HasColumnType("varchar(50)")
                    .HasComment("流程内容版本")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SortCode).HasComment("排序码");
            });

            modelBuilder.Entity<Form>(entity =>
            {
                entity.ToTable("form");

                entity.HasComment("表单模板表");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("表单模板Id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Content)
                    .HasColumnType("longtext")
                    .HasComment("表单原html模板未经处理的")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContentData)
                    .HasColumnType("longtext")
                    .HasComment("表单中的控件属性描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ContentParse)
                    .HasColumnType("longtext")
                    .HasComment("表单控件位置模板")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUserId)
                    .HasColumnType("varchar(50)")
                    .HasComment("创建用户主键")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateUserName)
                    .HasColumnType("varchar(50)")
                    .HasComment("创建用户")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DbName)
                    .HasColumnType("varchar(50)")
                    .HasComment("数据库名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DeleteMark).HasComment("删除标记");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Disabled).HasComment("有效");

                entity.Property(e => e.Fields).HasComment("字段个数");

                entity.Property(e => e.FrmType).HasComment("表单类型，0：默认动态表单；1：Web自定义表单");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.ModifyUserId)
                    .HasColumnType("varchar(50)")
                    .HasComment("修改用户主键")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModifyUserName)
                    .HasColumnType("varchar(50)")
                    .HasComment("修改用户")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(200)")
                    .HasComment("表单名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrgId)
                    .HasColumnType("varchar(50)")
                    .HasComment("所属部门")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SortCode).HasComment("排序码");

                entity.Property(e => e.WebId)
                    .HasColumnType("varchar(50)")
                    .HasComment("系统页面标识，当表单类型为用Web自定义的表单时，需要标识加载哪个页面")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Frmleavereq>(entity =>
            {
                entity.ToTable("frmleavereq");

                entity.HasComment("模拟一个自定页面的表单，该数据会关联到流程实例FrmData，可用于复杂页面的设计及后期的数据分析");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Attachment)
                    .HasColumnType("text")
                    .HasComment("附件，用于提交病假证据等")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUserId)
                    .HasColumnType("varchar(50)")
                    .HasComment("创建用户主键")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateUserName)
                    .HasColumnType("varchar(50)")
                    .HasComment("创建用户")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasComment("结束日期");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasComment("结束时间");

                entity.Property(e => e.FlowInstanceId)
                    .HasColumnType("varchar(50)")
                    .HasComment("所属流程ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RequestComment)
                    .HasColumnType("text")
                    .HasComment("请假说明")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RequestType)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasComment("请假分类，病假，事假，公休等")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasComment("开始日期");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasComment("开始时间");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnType("varchar(10)")
                    .HasComment("请假人姓名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("module");

                entity.HasComment("功能模块表");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("功能模块流水号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CascadeId)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("节点语义ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Code)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HotKey)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("热键")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IconName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("节点图标文件名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsAutoExpand).HasComment("是否自动展开");

                entity.Property(e => e.IsLeaf).HasComment("是否叶子节点");

                entity.Property(e => e.IsSys).HasComment("是否为系统模块");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("功能模块名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParentId)
                    .HasColumnType("varchar(50)")
                    .HasComment("父节点流水号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParentName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("父节点名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SortNo).HasComment("排序号");

                entity.Property(e => e.Status).HasComment("当前状态");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("主页面URL")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Vector)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("矢量图标")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Moduleelement>(entity =>
            {
                entity.ToTable("moduleelement");

                entity.HasComment("模块元素表(需要权限控制的按钮)");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("流水号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Attr)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("元素附加属性")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("元素样式")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DomId)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("DOM ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("元素图标")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ModuleId)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("功能模块Id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasComment("备注")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Script)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("元素调用脚本")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sort).HasComment("排序字段");

                entity.Property(e => e.TypeId)
                    .HasColumnType("varchar(50)")
                    .HasComment("分类ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TypeName)
                    .HasColumnType("varchar(20)")
                    .HasComment("分类名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Org>(entity =>
            {
                entity.ToTable("org");

                entity.HasComment("组织表");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("流水号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BizCode)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("业务对照码")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CascadeId)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("节点语义ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateId).HasComment("创建人ID");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.CustomCode)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("自定义扩展码")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HotKey)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("热键")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IconName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("节点图标文件名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsAutoExpand).HasComment("是否自动展开");

                entity.Property(e => e.IsLeaf).HasComment("是否叶子节点");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("组织名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParentId)
                    .HasColumnType("varchar(50)")
                    .HasComment("父节点流水号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParentName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("父节点名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SortNo).HasComment("排序号");

                entity.Property(e => e.Status).HasComment("当前状态");

                entity.Property(e => e.TypeId)
                    .HasColumnType("varchar(50)")
                    .HasComment("分类ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TypeName)
                    .HasColumnType("varchar(20)")
                    .HasComment("分类名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Relevance>(entity =>
            {
                entity.ToTable("relevance");

                entity.HasComment("多对多关系集中映射");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("流水号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasComment("描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ExtendInfo)
                    .HasColumnType("varchar(100)")
                    .HasComment("扩展信息")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstId)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("第一个表主键ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasComment("映射标识")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OperateTime)
                    .HasColumnType("datetime")
                    .HasComment("授权时间");

                entity.Property(e => e.OperatorId)
                    .HasColumnType("varchar(50)")
                    .HasComment("授权人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SecondId)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("第二个表主键ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status).HasComment("状态");

                entity.Property(e => e.ThirdId)
                    .HasColumnType("varchar(50)")
                    .HasComment("第三个表主键ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.ToTable("resource");

                entity.HasComment("资源表");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("资源标识")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AppId)
                    .HasColumnType("varchar(50)")
                    .HasComment("资源所属应用ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AppName)
                    .HasColumnType("varchar(50)")
                    .HasComment("所属应用名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CascadeId)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("' '")
                    .HasComment("节点语义ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUserId)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateUserName)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasComment("创建人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(500)")
                    .HasDefaultValueSql("' '")
                    .HasComment("描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Disable).HasComment("是否可用");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("' '")
                    .HasComment("名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParentId)
                    .HasColumnType("varchar(50)")
                    .HasComment("父节点流ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParentName)
                    .HasColumnType("varchar(50)")
                    .HasComment("父节点名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SortNo).HasComment("排序号");

                entity.Property(e => e.TypeId)
                    .HasColumnType("varchar(50)")
                    .HasComment("分类ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TypeName)
                    .HasColumnType("varchar(20)")
                    .HasComment("分类名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.UpdateUserId)
                    .HasColumnType("varchar(50)")
                    .HasComment("最后更新人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdateUserName)
                    .HasColumnType("varchar(200)")
                    .HasComment("最后更新人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.HasComment("角色表");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("Id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateId)
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("角色名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status).HasComment("当前状态");

                entity.Property(e => e.TypeId)
                    .HasColumnType("varchar(50)")
                    .HasComment("分类ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TypeName)
                    .HasColumnType("varchar(20)")
                    .HasComment("分类名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("stock");

                entity.HasComment("出入库信息表");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("数据ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("产品名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Number).HasComment("产品数量");

                entity.Property(e => e.OrgId)
                    .HasColumnType("varchar(50)")
                    .HasComment("组织ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10,1)")
                    .HasComment("产品单价");

                entity.Property(e => e.Status).HasComment("出库/入库");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("操作人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Viewable)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("可见范围")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Syslog>(entity =>
            {
                entity.ToTable("syslog");

                entity.HasComment("系统日志");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Application)
                    .HasColumnType("varchar(50)")
                    .HasComment("所属应用")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Content)
                    .HasColumnType("varchar(1000)")
                    .HasComment("日志内容")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateId)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("操作人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateName)
                    .HasColumnType("varchar(200)")
                    .HasComment("操作人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("记录时间");

                entity.Property(e => e.Href)
                    .HasColumnType("varchar(200)")
                    .HasComment("操作所属模块地址")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Ip)
                    .HasColumnType("varchar(20)")
                    .HasComment("操作机器的IP地址")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Result).HasComment("操作的结果：0：成功；1：失败；");

                entity.Property(e => e.TypeId)
                    .HasColumnType("varchar(50)")
                    .HasComment("分类ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TypeName)
                    .HasColumnType("varchar(20)")
                    .HasComment("分类名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Sysmessage>(entity =>
            {
                entity.ToTable("sysmessage");

                entity.HasComment("系统消息表");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Content)
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateId)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FromId)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FromName)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FromStatus).HasComment("-1:已删除；0:默认");

                entity.Property(e => e.Href)
                    .HasColumnType("varchar(200)")
                    .HasComment("点击消息跳转的页面等")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Title)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ToId)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ToName)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ToStatus).HasComment("-1:已删除；0:默认未读；1：已读");

                entity.Property(e => e.TypeId)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TypeName)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<TableDiary>(entity =>
            {
                entity.ToTable("table_diary");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("作者")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasComment("内容")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.PublishTime).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("标题")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnType("varchar(50)")
                    .HasComment("类型")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Ticksanalysis>(entity =>
            {
                entity.ToTable("ticksanalysis");

                entity.HasIndex(e => e.Code)
                    .HasName("PK");

                entity.HasIndex(e => e.Time)
                    .HasName("Seek");

                entity.Property(e => e.Time).HasColumnType("datetime");
            });

            modelBuilder.Entity<Uploadfile>(entity =>
            {
                entity.ToTable("uploadfile");

                entity.HasComment("文件");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("Id")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BelongApp)
                    .HasColumnType("varchar(200)")
                    .HasComment("所属应用")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BelongAppId)
                    .HasColumnType("varchar(50)")
                    .HasComment("所属应用ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("上传时间");

                entity.Property(e => e.CreateUserId)
                    .HasComment("上传人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateUserName)
                    .HasColumnType("varchar(50)")
                    .HasComment("上传人姓名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DeleteMark).HasComment("删除标识");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(200)")
                    .HasComment("描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Enable).HasComment("是否可用");

                entity.Property(e => e.Extension)
                    .HasColumnType("varchar(20)")
                    .HasComment("扩展名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasComment("文件名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("文件路径")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FileSize).HasComment("文件大小");

                entity.Property(e => e.FileType)
                    .HasColumnType("varchar(20)")
                    .HasComment("文件类型")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SortCode).HasComment("排序");

                entity.Property(e => e.Thumbnail)
                    .HasColumnType("text")
                    .HasComment("缩略图")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasComment("用户基本信息表");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("流水号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("用户登录帐号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BizCode)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("业务对照码")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateId)
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasComment("经办时间");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("用户姓名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasComment("密码")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sex).HasComment("性别");

                entity.Property(e => e.Status).HasComment("用户状态");

                entity.Property(e => e.TypeId)
                    .HasColumnType("varchar(50)")
                    .HasComment("分类ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TypeName)
                    .HasColumnType("varchar(20)")
                    .HasComment("分类名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Wmsinboundorderdtbl>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.OrderId })
                    .HasName("PRIMARY");

                entity.ToTable("wmsinboundorderdtbl");

                entity.HasComment("入库通知单明细");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("入库通知单明细号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrderId)
                    .HasColumnType("varchar(50)")
                    .HasComment("入库通知单号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AsnStatus)
                    .HasDefaultValueSql("'1'")
                    .HasComment("到货状况(SYS_GOODSARRIVESTATUS)");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUserId)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateUserName)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasComment("创建人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ExpireDate)
                    .HasColumnType("varchar(30)")
                    .HasComment("失效日期")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.GoodsBatch)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("商品批号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.GoodsId)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("商品编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HoldNum)
                    .HasColumnType("decimal(18,2)")
                    .HasComment("占用数量");

                entity.Property(e => e.InNum)
                    .HasColumnType("decimal(18,2)")
                    .HasComment("到货数量");

                entity.Property(e => e.InStockStatus).HasComment("是否收货中(0:非收货中,1:收货中)");

                entity.Property(e => e.LeaveNum)
                    .HasColumnType("decimal(18,2)")
                    .HasComment("剩余数量");

                entity.Property(e => e.OrderNum)
                    .HasColumnType("decimal(18,2)")
                    .HasComment("通知数量");

                entity.Property(e => e.OwnerId)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasComment("货主编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18,6)")
                    .HasComment("含税单价");

                entity.Property(e => e.PriceNoTax)
                    .HasColumnType("decimal(18,6)")
                    .HasComment("无税单价");

                entity.Property(e => e.ProdDate)
                    .HasColumnType("varchar(30)")
                    .HasComment("生产日期")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.QualityFlg)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("品质(SYS_QUALITYFLAG)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Remark)
                    .HasColumnType("varchar(128)")
                    .HasComment("备注")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TaxRate)
                    .HasColumnType("decimal(10,2)")
                    .HasComment("税率");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.UpdateUserId)
                    .HasColumnType("varchar(50)")
                    .HasComment("最后更新人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdateUserName)
                    .HasColumnType("varchar(200)")
                    .HasComment("最后更新人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Wmsinboundordertbl>(entity =>
            {
                entity.ToTable("wmsinboundordertbl");

                entity.HasComment("入库通知单（入库订单）");

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(50)")
                    .HasComment("入库通知单号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUserId)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateUserName)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasComment("创建人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Enable)
                    .IsRequired()
                    .HasDefaultValueSql("'1'")
                    .HasComment("有效标志");

                entity.Property(e => e.ExternalNo)
                    .HasColumnType("varchar(50)")
                    .HasComment("相关单据号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ExternalType)
                    .HasColumnType("varchar(50)")
                    .HasComment("相关单据类型")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.GoodsType)
                    .HasColumnType("varchar(50)")
                    .HasComment("商品类别")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InBondedArea).HasComment("是否入保税库(0:否,1:是)");

                entity.Property(e => e.OrderType)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("入库类型(SYS_INSTCTYPE)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrgId)
                    .HasColumnType("varchar(50)")
                    .HasComment("所属部门")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("varchar(50)")
                    .HasComment("货主编号(固定值CQM)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PurchaseNo)
                    .HasColumnType("varchar(30)")
                    .HasComment("采购单号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Remark)
                    .HasColumnType("varchar(256)")
                    .HasComment("备注")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReturnBoxNum)
                    .HasColumnType("decimal(8,0)")
                    .HasComment("销退箱数");

                entity.Property(e => e.ScheduledInboundTime)
                    .HasColumnType("datetime")
                    .HasComment("预定入库时间");

                entity.Property(e => e.ShipperId)
                    .HasColumnType("varchar(50)")
                    .HasComment("承运人编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status).HasComment("入库通知单状态(SYS_INSTCINFORMSTATUS)");

                entity.Property(e => e.StockId)
                    .IsRequired()
                    .HasColumnType("varchar(12)")
                    .HasComment("仓库编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SupplierId)
                    .HasColumnType("varchar(50)")
                    .HasComment("供应商编号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TransferType)
                    .HasColumnType("varchar(50)")
                    .HasComment("承运方式")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasComment("最后更新时间");

                entity.Property(e => e.UpdateUserId)
                    .HasColumnType("varchar(50)")
                    .HasComment("最后更新人ID")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdateUserName)
                    .HasColumnType("varchar(200)")
                    .HasComment("最后更新人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
