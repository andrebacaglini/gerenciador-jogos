USE [db_gerenciador_jogos]
GO
ALTER TABLE [dbo].[tb_emprestimo] DROP CONSTRAINT [FK_dbo.tb_emprestimo_dbo.tb_jogo_JogoId]
GO
ALTER TABLE [dbo].[tb_emprestimo] DROP CONSTRAINT [FK_dbo.tb_emprestimo_dbo.tb_amigo_AmigoId]
GO
/****** Object:  Table [dbo].[tb_usuario]    Script Date: 29/10/2017 19:25:09 ******/
DROP TABLE [dbo].[tb_usuario]
GO
/****** Object:  Table [dbo].[tb_jogo]    Script Date: 29/10/2017 19:25:09 ******/
DROP TABLE [dbo].[tb_jogo]
GO
/****** Object:  Table [dbo].[tb_emprestimo]    Script Date: 29/10/2017 19:25:09 ******/
DROP TABLE [dbo].[tb_emprestimo]
GO
/****** Object:  Table [dbo].[tb_amigo]    Script Date: 29/10/2017 19:25:09 ******/
DROP TABLE [dbo].[tb_amigo]
GO
/****** Object:  Table [dbo].[tb_amigo]    Script Date: 29/10/2017 19:25:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_amigo](
	[AmigoId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Sobrenome] [varchar](100) NOT NULL,
	[Apelido] [varchar](50) NULL,
 CONSTRAINT [PK_dbo.tb_amigo] PRIMARY KEY CLUSTERED 
(
	[AmigoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_emprestimo]    Script Date: 29/10/2017 19:25:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_emprestimo](
	[AmigoId] [int] NOT NULL,
	[JogoId] [int] NOT NULL,
	[DataEmprestimo] [datetime2](7) NOT NULL,
	[DataDevolucao] [datetime2](7) NULL,
 CONSTRAINT [PK_dbo.tb_emprestimo] PRIMARY KEY CLUSTERED 
(
	[AmigoId] ASC,
	[JogoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_jogo]    Script Date: 29/10/2017 19:25:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_jogo](
	[JogoId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Plataforma] [int] NOT NULL,
 CONSTRAINT [PK_dbo.tb_jogo] PRIMARY KEY CLUSTERED 
(
	[JogoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_usuario]    Script Date: 29/10/2017 19:25:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_usuario](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[NomeUsuario] [varchar](50) NOT NULL,
	[Senha] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[DataCadastro] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_dbo.tb_usuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tb_emprestimo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tb_emprestimo_dbo.tb_amigo_AmigoId] FOREIGN KEY([AmigoId])
REFERENCES [dbo].[tb_amigo] ([AmigoId])
GO
ALTER TABLE [dbo].[tb_emprestimo] CHECK CONSTRAINT [FK_dbo.tb_emprestimo_dbo.tb_amigo_AmigoId]
GO
ALTER TABLE [dbo].[tb_emprestimo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tb_emprestimo_dbo.tb_jogo_JogoId] FOREIGN KEY([JogoId])
REFERENCES [dbo].[tb_jogo] ([JogoId])
GO
ALTER TABLE [dbo].[tb_emprestimo] CHECK CONSTRAINT [FK_dbo.tb_emprestimo_dbo.tb_jogo_JogoId]
GO
