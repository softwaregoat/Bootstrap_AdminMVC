
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/04/2020 02:04:04
-- Generated from EDMX file: G:\Projects\Visual_Studio\ASP\admindx\admindx\Models\modelGdocx.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [gdocx];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_p_dependencia_p_organizacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[p_dependencia] DROP CONSTRAINT [FK_p_dependencia_p_organizacion];
GO
IF OBJECT_ID(N'[dbo].[FK_p_subdependencia_p_dependencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[p_subdependencia] DROP CONSTRAINT [FK_p_subdependencia_p_dependencia];
GO
IF OBJECT_ID(N'[dbo].[FK_p_subserie_p_serie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[p_subserie] DROP CONSTRAINT [FK_p_subserie_p_serie];
GO
IF OBJECT_ID(N'[dbo].[FK_p_tipodoc_p_subserie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[p_tipodoc] DROP CONSTRAINT [FK_p_tipodoc_p_subserie];
GO
IF OBJECT_ID(N'[dbo].[FK_p_tipoitem_p_tipodoc]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[p_tipoitem] DROP CONSTRAINT [FK_p_tipoitem_p_tipodoc];
GO
IF OBJECT_ID(N'[dbo].[FK_p_tiporesp_p_tipoitem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[p_tiporesp] DROP CONSTRAINT [FK_p_tiporesp_p_tipoitem];
GO
IF OBJECT_ID(N'[dbo].[FK_p_usuario_perfil_p_proyecto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[p_usuario_perfil] DROP CONSTRAINT [FK_p_usuario_perfil_p_proyecto];
GO
IF OBJECT_ID(N'[dbo].[FK_p_usuario_perfil_p_usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[p_usuario_perfil] DROP CONSTRAINT [FK_p_usuario_perfil_p_usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_t_carpeta_estado_p_usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_carpeta_estado] DROP CONSTRAINT [FK_t_carpeta_estado_p_usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_t_carpeta_estado_t_carpeta_estado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_carpeta_estado] DROP CONSTRAINT [FK_t_carpeta_estado_t_carpeta_estado];
GO
IF OBJECT_ID(N'[dbo].[FK_t_carpeta_p_tercero]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_carpeta] DROP CONSTRAINT [FK_t_carpeta_p_tercero];
GO
IF OBJECT_ID(N'[dbo].[FK_t_carpeta_t_lote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_carpeta] DROP CONSTRAINT [FK_t_carpeta_t_lote];
GO
IF OBJECT_ID(N'[dbo].[FK_t_documento_p_tipodoc]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_documento] DROP CONSTRAINT [FK_t_documento_p_tipodoc];
GO
IF OBJECT_ID(N'[dbo].[FK_t_documento_resp_id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_documento_resp] DROP CONSTRAINT [FK_t_documento_resp_id];
GO
IF OBJECT_ID(N'[dbo].[FK_t_documento_resp_id_item]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_documento_resp] DROP CONSTRAINT [FK_t_documento_resp_id_item];
GO
IF OBJECT_ID(N'[dbo].[FK_t_documento_t_carpeta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_documento] DROP CONSTRAINT [FK_t_documento_t_carpeta];
GO
IF OBJECT_ID(N'[dbo].[FK_t_documento_tercero_t_documento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_documento_tercero] DROP CONSTRAINT [FK_t_documento_tercero_t_documento];
GO
IF OBJECT_ID(N'[dbo].[FK_t_documento_tercero_t_tercero]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_documento_tercero] DROP CONSTRAINT [FK_t_documento_tercero_t_tercero];
GO
IF OBJECT_ID(N'[dbo].[FK_t_lote_p_proyecto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_lote] DROP CONSTRAINT [FK_t_lote_p_proyecto];
GO
IF OBJECT_ID(N'[dbo].[FK_t_lote_p_subdependencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_lote] DROP CONSTRAINT [FK_t_lote_p_subdependencia];
GO
IF OBJECT_ID(N'[dbo].[FK_t_lote_p_subserie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_lote] DROP CONSTRAINT [FK_t_lote_p_subserie];
GO
IF OBJECT_ID(N'[dbo].[FK_t_lpdf_hc_t_lpdf_hc]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_lpdf_hc] DROP CONSTRAINT [FK_t_lpdf_hc_t_lpdf_hc];
GO
IF OBJECT_ID(N'[dbo].[FK_t_metadata_t_metadata]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_metadata] DROP CONSTRAINT [FK_t_metadata_t_metadata];
GO
IF OBJECT_ID(N'[dbo].[FK_p_formato_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[p_formato] DROP CONSTRAINT [FK_p_formato_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_p_proyecto_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[p_proyecto] DROP CONSTRAINT [FK_p_proyecto_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_p_proyecto_FK_1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[p_proyecto] DROP CONSTRAINT [FK_p_proyecto_FK_1];
GO
IF OBJECT_ID(N'[dbo].[FK_p_recurso_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[p_recurso] DROP CONSTRAINT [FK_p_recurso_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_p_serie_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[p_serie] DROP CONSTRAINT [FK_p_serie_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_p_usuario_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[p_usuario] DROP CONSTRAINT [FK_p_usuario_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_recurso_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[p_recurso] DROP CONSTRAINT [FK_recurso_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_t_carpeta_id_usuario_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_carpeta] DROP CONSTRAINT [FK_t_carpeta_id_usuario_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_t_carpeta_usr_asignado_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_carpeta] DROP CONSTRAINT [FK_t_carpeta_usr_asignado_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_t_carpeta_usr_control_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_carpeta] DROP CONSTRAINT [FK_t_carpeta_usr_control_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_t_listpdf_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_listpdf] DROP CONSTRAINT [FK_t_listpdf_FK];
GO
IF OBJECT_ID(N'[dbo].[FK_t_listpdf_hc_FK]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_lpdf_hc] DROP CONSTRAINT [FK_t_listpdf_hc_FK];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[p_dependencia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[p_dependencia];
GO
IF OBJECT_ID(N'[dbo].[p_estado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[p_estado];
GO
IF OBJECT_ID(N'[dbo].[p_formato]', 'U') IS NOT NULL
    DROP TABLE [dbo].[p_formato];
GO
IF OBJECT_ID(N'[dbo].[p_organizacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[p_organizacion];
GO
IF OBJECT_ID(N'[dbo].[p_proyecto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[p_proyecto];
GO
IF OBJECT_ID(N'[dbo].[p_recurso]', 'U') IS NOT NULL
    DROP TABLE [dbo].[p_recurso];
GO
IF OBJECT_ID(N'[dbo].[p_serie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[p_serie];
GO
IF OBJECT_ID(N'[dbo].[p_subdependencia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[p_subdependencia];
GO
IF OBJECT_ID(N'[dbo].[p_subserie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[p_subserie];
GO
IF OBJECT_ID(N'[dbo].[p_tipodoc]', 'U') IS NOT NULL
    DROP TABLE [dbo].[p_tipodoc];
GO
IF OBJECT_ID(N'[dbo].[p_tipoitem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[p_tipoitem];
GO
IF OBJECT_ID(N'[dbo].[p_tiporesp]', 'U') IS NOT NULL
    DROP TABLE [dbo].[p_tiporesp];
GO
IF OBJECT_ID(N'[dbo].[p_usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[p_usuario];
GO
IF OBJECT_ID(N'[dbo].[p_usuario_perfil]', 'U') IS NOT NULL
    DROP TABLE [dbo].[p_usuario_perfil];
GO
IF OBJECT_ID(N'[dbo].[t_borrar_archivos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_borrar_archivos];
GO
IF OBJECT_ID(N'[dbo].[t_carpeta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_carpeta];
GO
IF OBJECT_ID(N'[dbo].[t_carpeta_estado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_carpeta_estado];
GO
IF OBJECT_ID(N'[dbo].[t_documento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_documento];
GO
IF OBJECT_ID(N'[dbo].[t_documento_resp]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_documento_resp];
GO
IF OBJECT_ID(N'[dbo].[t_documento_tercero]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_documento_tercero];
GO
IF OBJECT_ID(N'[dbo].[t_listpdf]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_listpdf];
GO
IF OBJECT_ID(N'[dbo].[t_lote]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_lote];
GO
IF OBJECT_ID(N'[dbo].[t_lpdf_hc]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_lpdf_hc];
GO
IF OBJECT_ID(N'[dbo].[t_metadata]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_metadata];
GO
IF OBJECT_ID(N'[dbo].[t_tercero]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_tercero];
GO
IF OBJECT_ID(N'[gdocxModelStoreContainer].[vw_prod_diario]', 'U') IS NOT NULL
    DROP TABLE [gdocxModelStoreContainer].[vw_prod_diario];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'p_dependencia'
CREATE TABLE [dbo].[p_dependencia] (
    [id] int  NOT NULL,
    [codigo] varchar(10)  NOT NULL,
    [nombre] varchar(80)  NOT NULL,
    [estado] varchar(10)  NOT NULL,
    [und_administrativa] varchar(150)  NULL,
    [id_organizacion] int  NOT NULL
);
GO

-- Creating table 'p_estado'
CREATE TABLE [dbo].[p_estado] (
    [id] int IDENTITY(1,1) NOT NULL,
    [activo] varchar(2)  NOT NULL
);
GO

-- Creating table 'p_organizacion'
CREATE TABLE [dbo].[p_organizacion] (
    [id_empresa] int  NOT NULL,
    [nombre] nchar(120)  NOT NULL,
    [activo] int  NOT NULL
);
GO

-- Creating table 'p_proyecto'
CREATE TABLE [dbo].[p_proyecto] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nom_proyecto] nchar(100)  NOT NULL,
    [id_empresa] int  NOT NULL,
    [activo] int  NOT NULL,
    [ruta_proyecto] varchar(255)  NULL,
    [extension] nchar(10)  NOT NULL,
    [meta_diaria] int  NULL,
    [ruta_salida] nchar(255)  NULL,
    [ruta_reportes] nchar(255)  NULL,
    [ruta_firma_entrada] varchar(255)  NULL,
    [ruta_firma_salida] varchar(255)  NULL,
    [ruta_servidor] nchar(255)  NULL,
    [nivel_ocr] int  NULL
);
GO

-- Creating table 'p_recurso'
CREATE TABLE [dbo].[p_recurso] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_proyecto] int  NOT NULL,
    [nom_recurso] varchar(100)  NOT NULL,
    [proc_ocr] varchar(2)  NOT NULL,
    [proc_pdfa] varchar(2)  NOT NULL,
    [auditoria] varchar(2)  NOT NULL,
    [ruta_pdf] varchar(255)  NOT NULL,
    [nom_carpeta] varchar(100)  NULL,
    [activo] int  NOT NULL,
    [proc_hc] varchar(2)  NOT NULL,
    [ruta_s3] varchar(255)  NULL
);
GO

-- Creating table 'p_serie'
CREATE TABLE [dbo].[p_serie] (
    [id] int IDENTITY(1,1) NOT NULL,
    [codigo] varchar(20)  NULL,
    [nombre] varchar(50)  NOT NULL,
    [id_organizacion] int  NOT NULL
);
GO

-- Creating table 'p_subdependencia'
CREATE TABLE [dbo].[p_subdependencia] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_dependencia] int  NOT NULL,
    [cod] varchar(15)  NULL,
    [nombre] varchar(80)  NOT NULL
);
GO

-- Creating table 'p_subserie'
CREATE TABLE [dbo].[p_subserie] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_serie] int  NOT NULL,
    [codigo] varchar(25)  NULL,
    [nombre] varchar(200)  NOT NULL,
    [pag_defecto] int  NULL
);
GO

-- Creating table 'p_tipodoc'
CREATE TABLE [dbo].[p_tipodoc] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_subserie] int  NOT NULL,
    [cod] varchar(10)  NULL,
    [nombre] varchar(200)  NOT NULL,
    [img] varchar(max)  NULL,
    [multiterceros] int  NOT NULL,
    [principal] int  NOT NULL,
    [excluir] bit  NOT NULL
);
GO

-- Creating table 'p_tipoitem'
CREATE TABLE [dbo].[p_tipoitem] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_tipo] int  NOT NULL,
    [type] varchar(12)  NOT NULL,
    [descripcion] varchar(100)  NOT NULL,
    [requerido] int  NOT NULL,
    [orden] int  NOT NULL,
    [activo] int  NOT NULL
);
GO

-- Creating table 'p_tiporesp'
CREATE TABLE [dbo].[p_tiporesp] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_item] int  NOT NULL,
    [nombre] varchar(100)  NOT NULL,
    [valor] varchar(255)  NOT NULL,
    [vr_padre] varchar(255)  NULL,
    [activo] int  NOT NULL
);
GO

-- Creating table 'p_usuario'
CREATE TABLE [dbo].[p_usuario] (
    [id] int  NOT NULL,
    [identificacion] int  NOT NULL,
    [nombres] varchar(30)  NOT NULL,
    [apellidos] varchar(30)  NOT NULL,
    [email] varchar(90)  NULL,
    [clave] nchar(50)  NOT NULL,
    [telefono] nchar(40)  NULL,
    [activo] int  NOT NULL,
    [usuario] nchar(30)  NOT NULL
);
GO

-- Creating table 'p_usuario_perfil'
CREATE TABLE [dbo].[p_usuario_perfil] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_usuario] int  NOT NULL,
    [id_proyecto] int  NOT NULL,
    [superadmin] int  NOT NULL,
    [web_admin] int  NOT NULL,
    [web_consulta] int  NOT NULL,
    [loc_admin] int  NOT NULL,
    [loc_index] int  NOT NULL,
    [loc_calidad] int  NOT NULL,
    [loc_consulta] int  NOT NULL,
    [telemetria] int  NOT NULL
);
GO

-- Creating table 't_borrar_archivos'
CREATE TABLE [dbo].[t_borrar_archivos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [ruta] nchar(250)  NOT NULL,
    [nom_archivo] nchar(200)  NOT NULL,
    [borrado] nchar(1)  NOT NULL
);
GO

-- Creating table 't_carpeta'
CREATE TABLE [dbo].[t_carpeta] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_lote] int  NULL,
    [nro_expediente] varchar(50)  NULL,
    [nom_expediente] varchar(1000)  NULL,
    [nro_caja] varchar(50)  NULL,
    [nro_carpeta] int  NULL,
    [paginas] int  NULL,
    [fecha_expediente_ini] datetime  NULL,
    [fecha_expediente_fin] datetime  NULL,
    [total_folios] int  NULL,
    [id_tercero] int  NULL,
    [ejecucion] int  NOT NULL,
    [estado] varchar(1)  NOT NULL,
    [idusr_asignado] int  NULL,
    [id_usuario] int  NULL,
    [fecha_registro] datetime  NOT NULL,
    [exp_ocr] bit  NULL,
    [exp_pdfa] bit  NULL,
    [exp_firma] bit  NULL,
    [idusr_control] int  NULL,
    [hc_inicio] varchar(50)  NULL,
    [hc_fin] varchar(50)  NULL,
    [tomo] varchar(50)  NULL
);
GO

-- Creating table 't_carpeta_estado'
CREATE TABLE [dbo].[t_carpeta_estado] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_carpeta] int  NOT NULL,
    [id_usuario] int  NULL,
    [fase] varchar(1)  NOT NULL,
    [rechazado] int  NOT NULL,
    [fecha_estado] datetime  NOT NULL,
    [observacion] varchar(255)  NULL,
    [modificacion_pdf] bit  NULL
);
GO

-- Creating table 't_documento'
CREATE TABLE [dbo].[t_documento] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_carpeta] int  NOT NULL,
    [id_tipodoc] int  NULL,
    [pag_ini] int  NULL,
    [pag_fin] int  NULL,
    [ruta_docpdf] nvarchar(255)  NULL,
    [doc_ocr] bit  NULL,
    [doc_pdfa] bit  NULL,
    [doc_firma] bit  NULL,
    [folio_ini] int  NULL,
    [folio_fin] int  NULL,
    [observacion] nchar(255)  NULL,
    [fecha] datetime  NULL,
    [requiere_seleccion] bit  NOT NULL,
    [item] varchar(5)  NULL
);
GO

-- Creating table 't_documento_tercero'
CREATE TABLE [dbo].[t_documento_tercero] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_documento] int  NOT NULL,
    [id_tercero] int  NOT NULL
);
GO

-- Creating table 't_listpdf'
CREATE TABLE [dbo].[t_listpdf] (
    [id] int IDENTITY(1,1) NOT NULL,
    [directorio] varchar(260)  NOT NULL,
    [nombre] varchar(150)  NOT NULL,
    [tamanio] bigint  NOT NULL,
    [fecha_modificacion] datetime  NULL,
    [fecha_creacion] datetime  NULL,
    [fecha_cargue] datetime  NULL,
    [ancho] int  NULL,
    [alto] int  NULL,
    [dpix] float  NULL,
    [dpiy] float  NULL,
    [paginas] int  NOT NULL,
    [id_usuario] int  NULL,
    [ocr] nchar(2)  NULL,
    [pag_ancho] float  NULL,
    [pag_alto] float  NULL,
    [escala_gris] nchar(2)  NULL,
    [firma] int  NULL,
    [firma_valida] int  NULL,
    [dpi] float  NULL,
    [modificado] nchar(2)  NULL,
    [metadata] nchar(2)  NULL,
    [pdfa] nchar(2)  NULL,
    [repetido] nchar(2)  NULL,
    [id_proyecto] int  NOT NULL,
    [msj_error] varchar(max)  NULL
);
GO

-- Creating table 't_lote'
CREATE TABLE [dbo].[t_lote] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nom_lote] varchar(50)  NOT NULL,
    [id_subdependencia] int  NULL,
    [id_subserie] int  NULL,
    [id_proyecto] int  NULL,
    [fecha_ingreso] datetime  NOT NULL,
    [marco] varchar(80)  NULL
);
GO

-- Creating table 't_lpdf_hc'
CREATE TABLE [dbo].[t_lpdf_hc] (
    [id] int IDENTITY(1,1) NOT NULL,
    [directorio] varchar(260)  NOT NULL,
    [nombre] varchar(150)  NOT NULL,
    [tamanio] bigint  NOT NULL,
    [fecha_modificacion] datetime  NULL,
    [fecha_creacion] datetime  NULL,
    [fecha_cargue] datetime  NULL,
    [ancho] int  NULL,
    [alto] int  NULL,
    [dpix] float  NULL,
    [dpiy] float  NULL,
    [paginas] int  NOT NULL,
    [id_usuario] int  NULL,
    [ocr] nchar(2)  NULL,
    [pag_ancho] float  NULL,
    [pag_alto] float  NULL,
    [escala_gris] nchar(2)  NULL,
    [firma] int  NULL,
    [firma_valida] int  NULL,
    [dpi] float  NULL,
    [modificado] nchar(2)  NULL,
    [metadata] nchar(2)  NULL,
    [pdfa] nchar(2)  NULL,
    [repetido] nchar(2)  NULL,
    [id_proyecto] int  NOT NULL,
    [msj_error] varchar(max)  NULL,
    [s3] varchar(255)  NULL,
    [textract] varchar(512)  NULL,
    [nro_pag_hc] int  NULL
);
GO

-- Creating table 't_metadata'
CREATE TABLE [dbo].[t_metadata] (
    [id] int IDENTITY(1,1) NOT NULL,
    [direccion_admin] nchar(150)  NULL,
    [oficina] nchar(200)  NULL,
    [serie] nchar(100)  NULL,
    [subserie] nchar(150)  NULL,
    [identificador] int  NULL,
    [expediente] nchar(120)  NULL,
    [tomo] nchar(10)  NULL,
    [fecha_inicial] datetime  NULL,
    [fecha_final] datetime  NULL,
    [folio_ini] int  NULL,
    [folio_fin] int  NULL,
    [imagenes] int  NULL,
    [observaciones] nchar(300)  NULL,
    [notas] nchar(200)  NULL,
    [captura] datetime  NULL,
    [calidad] datetime  NULL,
    [nom_archivo] nchar(255)  NOT NULL,
    [id_recurso] int  NOT NULL,
    [fecha_ingreso] datetime  NULL,
    [ruta_final] varchar(255)  NULL,
    [directorio] varchar(255)  NULL,
    [archivo_salida] varchar(255)  NULL
);
GO

-- Creating table 't_tercero'
CREATE TABLE [dbo].[t_tercero] (
    [id] int IDENTITY(1,1) NOT NULL,
    [identificacion] varchar(50)  NOT NULL,
    [nombres] varchar(80)  NOT NULL,
    [tipo_documento] nchar(80)  NULL,
    [nro_tarjeta] int  NULL,
    [tipo_tercero] varchar(10)  NOT NULL,
    [lugar_exp] nchar(60)  NULL,
    [apellidos] varchar(80)  NOT NULL
);
GO

-- Creating table 'p_formato'
CREATE TABLE [dbo].[p_formato] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_proyecto] int  NOT NULL,
    [hc_titulo1] nchar(100)  NULL,
    [hc_titulo2] nchar(100)  NULL,
    [hc_titulo3] nchar(100)  NULL,
    [hc_cal_codigo] nchar(50)  NULL,
    [hc_cal_version] nchar(50)  NULL,
    [hc_cal_fecha] nchar(50)  NULL,
    [hc_nota1] nchar(512)  NULL,
    [hc_nota2] nchar(512)  NULL,
    [rc_titulo1] nchar(100)  NULL,
    [rc_titulo2] nchar(100)  NULL,
    [rc_titulo3] nchar(100)  NULL,
    [rc_cal_codigo] nchar(50)  NULL,
    [rc_cal_version] nchar(50)  NULL,
    [rc_cal_fecha] nchar(50)  NULL,
    [rc_marco_legal] int  NULL,
    [fecha_inicial_defecto] datetime  NULL,
    [fi_cal_codigo] nchar(50)  NULL,
    [fi_cal_version] nchar(50)  NULL,
    [fi_cal_fecha] nchar(50)  NULL,
    [fi_titulo1] varchar(100)  NULL,
    [fi_titulo2] varchar(100)  NULL,
    [fi_titulo3] varchar(100)  NULL,
    [fi_objeto] nchar(100)  NULL,
    [fi_elaboradox] varchar(100)  NULL,
    [fi_elaboradox_cargo] varchar(100)  NULL,
    [fi_entregadox] varchar(100)  NULL,
    [fi_entregadox_cargo] varchar(100)  NULL,
    [fi_recibidox] varchar(100)  NULL,
    [fi_recibidox_cargo] varchar(100)  NULL,
    [fi_lugar] varchar(100)  NULL,
    [fi_fecha] varchar(100)  NULL,
    [cj_titulo1] varchar(100)  NULL,
    [cj_titulo2] varchar(100)  NULL,
    [cj_titulo3] varchar(100)  NULL,
    [cj_cal_codigo] varchar(50)  NULL,
    [cj_cal_version] varchar(50)  NULL,
    [cj_cal_fecha] varchar(50)  NULL
);
GO

-- Creating table 't_documento_resp'
CREATE TABLE [dbo].[t_documento_resp] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_documento] int  NOT NULL,
    [id_item] int  NOT NULL,
    [valor] nchar(255)  NOT NULL
);
GO

-- Creating table 'vw_prod_diario'
CREATE TABLE [dbo].[vw_prod_diario] (
    [id_proyecto] int  NULL,
    [id_carpeta] int  NOT NULL,
    [nom_lote] varchar(50)  NOT NULL,
    [nro_caja] varchar(50)  NULL,
    [nro_expediente] varchar(50)  NULL,
    [f_asignacion] datetime  NULL,
    [asignado] varchar(61)  NOT NULL,
    [f_realizado] datetime  NULL,
    [Realizado] varchar(61)  NOT NULL,
    [hora] time  NULL,
    [nro_carpeta] int  NULL,
    [hc_inicio] varchar(50)  NULL,
    [hc_fin] varchar(50)  NULL,
    [tomo] varchar(50)  NULL,
    [folio_inicial] int  NULL,
    [folio_final] int  NULL,
    [registros] int  NULL,
    [folio_total] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'p_dependencia'
ALTER TABLE [dbo].[p_dependencia]
ADD CONSTRAINT [PK_p_dependencia]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'p_estado'
ALTER TABLE [dbo].[p_estado]
ADD CONSTRAINT [PK_p_estado]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id_empresa] in table 'p_organizacion'
ALTER TABLE [dbo].[p_organizacion]
ADD CONSTRAINT [PK_p_organizacion]
    PRIMARY KEY CLUSTERED ([id_empresa] ASC);
GO

-- Creating primary key on [id] in table 'p_proyecto'
ALTER TABLE [dbo].[p_proyecto]
ADD CONSTRAINT [PK_p_proyecto]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'p_recurso'
ALTER TABLE [dbo].[p_recurso]
ADD CONSTRAINT [PK_p_recurso]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'p_serie'
ALTER TABLE [dbo].[p_serie]
ADD CONSTRAINT [PK_p_serie]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'p_subdependencia'
ALTER TABLE [dbo].[p_subdependencia]
ADD CONSTRAINT [PK_p_subdependencia]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'p_subserie'
ALTER TABLE [dbo].[p_subserie]
ADD CONSTRAINT [PK_p_subserie]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'p_tipodoc'
ALTER TABLE [dbo].[p_tipodoc]
ADD CONSTRAINT [PK_p_tipodoc]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'p_tipoitem'
ALTER TABLE [dbo].[p_tipoitem]
ADD CONSTRAINT [PK_p_tipoitem]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'p_tiporesp'
ALTER TABLE [dbo].[p_tiporesp]
ADD CONSTRAINT [PK_p_tiporesp]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'p_usuario'
ALTER TABLE [dbo].[p_usuario]
ADD CONSTRAINT [PK_p_usuario]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'p_usuario_perfil'
ALTER TABLE [dbo].[p_usuario_perfil]
ADD CONSTRAINT [PK_p_usuario_perfil]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 't_borrar_archivos'
ALTER TABLE [dbo].[t_borrar_archivos]
ADD CONSTRAINT [PK_t_borrar_archivos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 't_carpeta'
ALTER TABLE [dbo].[t_carpeta]
ADD CONSTRAINT [PK_t_carpeta]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 't_carpeta_estado'
ALTER TABLE [dbo].[t_carpeta_estado]
ADD CONSTRAINT [PK_t_carpeta_estado]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 't_documento'
ALTER TABLE [dbo].[t_documento]
ADD CONSTRAINT [PK_t_documento]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 't_documento_tercero'
ALTER TABLE [dbo].[t_documento_tercero]
ADD CONSTRAINT [PK_t_documento_tercero]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 't_listpdf'
ALTER TABLE [dbo].[t_listpdf]
ADD CONSTRAINT [PK_t_listpdf]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 't_lote'
ALTER TABLE [dbo].[t_lote]
ADD CONSTRAINT [PK_t_lote]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 't_lpdf_hc'
ALTER TABLE [dbo].[t_lpdf_hc]
ADD CONSTRAINT [PK_t_lpdf_hc]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 't_metadata'
ALTER TABLE [dbo].[t_metadata]
ADD CONSTRAINT [PK_t_metadata]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 't_tercero'
ALTER TABLE [dbo].[t_tercero]
ADD CONSTRAINT [PK_t_tercero]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'p_formato'
ALTER TABLE [dbo].[p_formato]
ADD CONSTRAINT [PK_p_formato]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 't_documento_resp'
ALTER TABLE [dbo].[t_documento_resp]
ADD CONSTRAINT [PK_t_documento_resp]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id_carpeta], [nom_lote], [asignado], [Realizado] in table 'vw_prod_diario'
ALTER TABLE [dbo].[vw_prod_diario]
ADD CONSTRAINT [PK_vw_prod_diario]
    PRIMARY KEY CLUSTERED ([id_carpeta], [nom_lote], [asignado], [Realizado] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [id_organizacion] in table 'p_dependencia'
ALTER TABLE [dbo].[p_dependencia]
ADD CONSTRAINT [FK_p_dependencia_p_organizacion]
    FOREIGN KEY ([id_organizacion])
    REFERENCES [dbo].[p_organizacion]
        ([id_empresa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_p_dependencia_p_organizacion'
CREATE INDEX [IX_FK_p_dependencia_p_organizacion]
ON [dbo].[p_dependencia]
    ([id_organizacion]);
GO

-- Creating foreign key on [id_dependencia] in table 'p_subdependencia'
ALTER TABLE [dbo].[p_subdependencia]
ADD CONSTRAINT [FK_p_subdependencia_p_dependencia]
    FOREIGN KEY ([id_dependencia])
    REFERENCES [dbo].[p_dependencia]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_p_subdependencia_p_dependencia'
CREATE INDEX [IX_FK_p_subdependencia_p_dependencia]
ON [dbo].[p_subdependencia]
    ([id_dependencia]);
GO

-- Creating foreign key on [activo] in table 'p_proyecto'
ALTER TABLE [dbo].[p_proyecto]
ADD CONSTRAINT [FK_p_proyecto_FK_1]
    FOREIGN KEY ([activo])
    REFERENCES [dbo].[p_estado]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_p_proyecto_FK_1'
CREATE INDEX [IX_FK_p_proyecto_FK_1]
ON [dbo].[p_proyecto]
    ([activo]);
GO

-- Creating foreign key on [activo] in table 'p_recurso'
ALTER TABLE [dbo].[p_recurso]
ADD CONSTRAINT [FK_p_recurso_FK]
    FOREIGN KEY ([activo])
    REFERENCES [dbo].[p_estado]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_p_recurso_FK'
CREATE INDEX [IX_FK_p_recurso_FK]
ON [dbo].[p_recurso]
    ([activo]);
GO

-- Creating foreign key on [activo] in table 'p_usuario'
ALTER TABLE [dbo].[p_usuario]
ADD CONSTRAINT [FK_p_usuario_FK]
    FOREIGN KEY ([activo])
    REFERENCES [dbo].[p_estado]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_p_usuario_FK'
CREATE INDEX [IX_FK_p_usuario_FK]
ON [dbo].[p_usuario]
    ([activo]);
GO

-- Creating foreign key on [id_empresa] in table 'p_proyecto'
ALTER TABLE [dbo].[p_proyecto]
ADD CONSTRAINT [FK_p_proyecto_FK]
    FOREIGN KEY ([id_empresa])
    REFERENCES [dbo].[p_organizacion]
        ([id_empresa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_p_proyecto_FK'
CREATE INDEX [IX_FK_p_proyecto_FK]
ON [dbo].[p_proyecto]
    ([id_empresa]);
GO

-- Creating foreign key on [id_proyecto] in table 'p_usuario_perfil'
ALTER TABLE [dbo].[p_usuario_perfil]
ADD CONSTRAINT [FK_p_usuario_perfil_p_proyecto]
    FOREIGN KEY ([id_proyecto])
    REFERENCES [dbo].[p_proyecto]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_p_usuario_perfil_p_proyecto'
CREATE INDEX [IX_FK_p_usuario_perfil_p_proyecto]
ON [dbo].[p_usuario_perfil]
    ([id_proyecto]);
GO

-- Creating foreign key on [id_proyecto] in table 't_lote'
ALTER TABLE [dbo].[t_lote]
ADD CONSTRAINT [FK_t_lote_p_proyecto]
    FOREIGN KEY ([id_proyecto])
    REFERENCES [dbo].[p_proyecto]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_t_lote_p_proyecto'
CREATE INDEX [IX_FK_t_lote_p_proyecto]
ON [dbo].[t_lote]
    ([id_proyecto]);
GO

-- Creating foreign key on [id_proyecto] in table 'p_recurso'
ALTER TABLE [dbo].[p_recurso]
ADD CONSTRAINT [FK_recurso_FK]
    FOREIGN KEY ([id_proyecto])
    REFERENCES [dbo].[p_proyecto]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_recurso_FK'
CREATE INDEX [IX_FK_recurso_FK]
ON [dbo].[p_recurso]
    ([id_proyecto]);
GO

-- Creating foreign key on [id_proyecto] in table 't_listpdf'
ALTER TABLE [dbo].[t_listpdf]
ADD CONSTRAINT [FK_t_listpdf_FK]
    FOREIGN KEY ([id_proyecto])
    REFERENCES [dbo].[p_proyecto]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_t_listpdf_FK'
CREATE INDEX [IX_FK_t_listpdf_FK]
ON [dbo].[t_listpdf]
    ([id_proyecto]);
GO

-- Creating foreign key on [id_proyecto] in table 't_lpdf_hc'
ALTER TABLE [dbo].[t_lpdf_hc]
ADD CONSTRAINT [FK_t_listpdf_hc_FK]
    FOREIGN KEY ([id_proyecto])
    REFERENCES [dbo].[p_proyecto]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_t_listpdf_hc_FK'
CREATE INDEX [IX_FK_t_listpdf_hc_FK]
ON [dbo].[t_lpdf_hc]
    ([id_proyecto]);
GO

-- Creating foreign key on [id_serie] in table 'p_subserie'
ALTER TABLE [dbo].[p_subserie]
ADD CONSTRAINT [FK_p_subserie_p_serie]
    FOREIGN KEY ([id_serie])
    REFERENCES [dbo].[p_serie]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_p_subserie_p_serie'
CREATE INDEX [IX_FK_p_subserie_p_serie]
ON [dbo].[p_subserie]
    ([id_serie]);
GO

-- Creating foreign key on [id_subdependencia] in table 't_lote'
ALTER TABLE [dbo].[t_lote]
ADD CONSTRAINT [FK_t_lote_p_subdependencia]
    FOREIGN KEY ([id_subdependencia])
    REFERENCES [dbo].[p_subdependencia]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_t_lote_p_subdependencia'
CREATE INDEX [IX_FK_t_lote_p_subdependencia]
ON [dbo].[t_lote]
    ([id_subdependencia]);
GO

-- Creating foreign key on [id_subserie] in table 'p_tipodoc'
ALTER TABLE [dbo].[p_tipodoc]
ADD CONSTRAINT [FK_p_tipodoc_p_subserie]
    FOREIGN KEY ([id_subserie])
    REFERENCES [dbo].[p_subserie]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_p_tipodoc_p_subserie'
CREATE INDEX [IX_FK_p_tipodoc_p_subserie]
ON [dbo].[p_tipodoc]
    ([id_subserie]);
GO

-- Creating foreign key on [id_subserie] in table 't_lote'
ALTER TABLE [dbo].[t_lote]
ADD CONSTRAINT [FK_t_lote_p_subserie]
    FOREIGN KEY ([id_subserie])
    REFERENCES [dbo].[p_subserie]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_t_lote_p_subserie'
CREATE INDEX [IX_FK_t_lote_p_subserie]
ON [dbo].[t_lote]
    ([id_subserie]);
GO

-- Creating foreign key on [id_tipo] in table 'p_tipoitem'
ALTER TABLE [dbo].[p_tipoitem]
ADD CONSTRAINT [FK_p_tipoitem_p_tipodoc]
    FOREIGN KEY ([id_tipo])
    REFERENCES [dbo].[p_tipodoc]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_p_tipoitem_p_tipodoc'
CREATE INDEX [IX_FK_p_tipoitem_p_tipodoc]
ON [dbo].[p_tipoitem]
    ([id_tipo]);
GO

-- Creating foreign key on [id_tipodoc] in table 't_documento'
ALTER TABLE [dbo].[t_documento]
ADD CONSTRAINT [FK_t_documento_p_tipodoc]
    FOREIGN KEY ([id_tipodoc])
    REFERENCES [dbo].[p_tipodoc]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_t_documento_p_tipodoc'
CREATE INDEX [IX_FK_t_documento_p_tipodoc]
ON [dbo].[t_documento]
    ([id_tipodoc]);
GO

-- Creating foreign key on [id_item] in table 'p_tiporesp'
ALTER TABLE [dbo].[p_tiporesp]
ADD CONSTRAINT [FK_p_tiporesp_p_tipoitem]
    FOREIGN KEY ([id_item])
    REFERENCES [dbo].[p_tipoitem]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_p_tiporesp_p_tipoitem'
CREATE INDEX [IX_FK_p_tiporesp_p_tipoitem]
ON [dbo].[p_tiporesp]
    ([id_item]);
GO

-- Creating foreign key on [id_usuario] in table 'p_usuario_perfil'
ALTER TABLE [dbo].[p_usuario_perfil]
ADD CONSTRAINT [FK_p_usuario_perfil_p_usuario]
    FOREIGN KEY ([id_usuario])
    REFERENCES [dbo].[p_usuario]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_p_usuario_perfil_p_usuario'
CREATE INDEX [IX_FK_p_usuario_perfil_p_usuario]
ON [dbo].[p_usuario_perfil]
    ([id_usuario]);
GO

-- Creating foreign key on [id_carpeta] in table 't_carpeta_estado'
ALTER TABLE [dbo].[t_carpeta_estado]
ADD CONSTRAINT [FK_t_carpeta_estado_t_carpeta_estado]
    FOREIGN KEY ([id_carpeta])
    REFERENCES [dbo].[t_carpeta]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_t_carpeta_estado_t_carpeta_estado'
CREATE INDEX [IX_FK_t_carpeta_estado_t_carpeta_estado]
ON [dbo].[t_carpeta_estado]
    ([id_carpeta]);
GO

-- Creating foreign key on [id_tercero] in table 't_carpeta'
ALTER TABLE [dbo].[t_carpeta]
ADD CONSTRAINT [FK_t_carpeta_p_tercero]
    FOREIGN KEY ([id_tercero])
    REFERENCES [dbo].[t_tercero]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_t_carpeta_p_tercero'
CREATE INDEX [IX_FK_t_carpeta_p_tercero]
ON [dbo].[t_carpeta]
    ([id_tercero]);
GO

-- Creating foreign key on [id_lote] in table 't_carpeta'
ALTER TABLE [dbo].[t_carpeta]
ADD CONSTRAINT [FK_t_carpeta_t_lote]
    FOREIGN KEY ([id_lote])
    REFERENCES [dbo].[t_lote]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_t_carpeta_t_lote'
CREATE INDEX [IX_FK_t_carpeta_t_lote]
ON [dbo].[t_carpeta]
    ([id_lote]);
GO

-- Creating foreign key on [id_carpeta] in table 't_documento'
ALTER TABLE [dbo].[t_documento]
ADD CONSTRAINT [FK_t_documento_t_carpeta]
    FOREIGN KEY ([id_carpeta])
    REFERENCES [dbo].[t_carpeta]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_t_documento_t_carpeta'
CREATE INDEX [IX_FK_t_documento_t_carpeta]
ON [dbo].[t_documento]
    ([id_carpeta]);
GO

-- Creating foreign key on [id_documento] in table 't_documento_tercero'
ALTER TABLE [dbo].[t_documento_tercero]
ADD CONSTRAINT [FK_t_documento_tercero_t_documento]
    FOREIGN KEY ([id_documento])
    REFERENCES [dbo].[t_documento]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_t_documento_tercero_t_documento'
CREATE INDEX [IX_FK_t_documento_tercero_t_documento]
ON [dbo].[t_documento_tercero]
    ([id_documento]);
GO

-- Creating foreign key on [id_tercero] in table 't_documento_tercero'
ALTER TABLE [dbo].[t_documento_tercero]
ADD CONSTRAINT [FK_t_documento_tercero_t_tercero]
    FOREIGN KEY ([id_tercero])
    REFERENCES [dbo].[t_tercero]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_t_documento_tercero_t_tercero'
CREATE INDEX [IX_FK_t_documento_tercero_t_tercero]
ON [dbo].[t_documento_tercero]
    ([id_tercero]);
GO

-- Creating foreign key on [id] in table 't_lpdf_hc'
ALTER TABLE [dbo].[t_lpdf_hc]
ADD CONSTRAINT [FK_t_lpdf_hc_t_lpdf_hc]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[t_lpdf_hc]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 't_metadata'
ALTER TABLE [dbo].[t_metadata]
ADD CONSTRAINT [FK_t_metadata_t_metadata]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[t_metadata]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id_proyecto] in table 'p_formato'
ALTER TABLE [dbo].[p_formato]
ADD CONSTRAINT [FK_p_formato_FK]
    FOREIGN KEY ([id_proyecto])
    REFERENCES [dbo].[p_proyecto]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_p_formato_FK'
CREATE INDEX [IX_FK_p_formato_FK]
ON [dbo].[p_formato]
    ([id_proyecto]);
GO

-- Creating foreign key on [id_organizacion] in table 'p_serie'
ALTER TABLE [dbo].[p_serie]
ADD CONSTRAINT [FK_p_serie_FK]
    FOREIGN KEY ([id_organizacion])
    REFERENCES [dbo].[p_organizacion]
        ([id_empresa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_p_serie_FK'
CREATE INDEX [IX_FK_p_serie_FK]
ON [dbo].[p_serie]
    ([id_organizacion]);
GO

-- Creating foreign key on [id_item] in table 't_documento_resp'
ALTER TABLE [dbo].[t_documento_resp]
ADD CONSTRAINT [FK_t_documento_resp_id_item]
    FOREIGN KEY ([id_item])
    REFERENCES [dbo].[p_tipoitem]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_t_documento_resp_id_item'
CREATE INDEX [IX_FK_t_documento_resp_id_item]
ON [dbo].[t_documento_resp]
    ([id_item]);
GO

-- Creating foreign key on [id_usuario] in table 't_carpeta'
ALTER TABLE [dbo].[t_carpeta]
ADD CONSTRAINT [FK_t_carpeta_id_usuario_FK]
    FOREIGN KEY ([id_usuario])
    REFERENCES [dbo].[p_usuario]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_t_carpeta_id_usuario_FK'
CREATE INDEX [IX_FK_t_carpeta_id_usuario_FK]
ON [dbo].[t_carpeta]
    ([id_usuario]);
GO

-- Creating foreign key on [idusr_asignado] in table 't_carpeta'
ALTER TABLE [dbo].[t_carpeta]
ADD CONSTRAINT [FK_t_carpeta_usr_asignado_FK]
    FOREIGN KEY ([idusr_asignado])
    REFERENCES [dbo].[p_usuario]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_t_carpeta_usr_asignado_FK'
CREATE INDEX [IX_FK_t_carpeta_usr_asignado_FK]
ON [dbo].[t_carpeta]
    ([idusr_asignado]);
GO

-- Creating foreign key on [id_documento] in table 't_documento_resp'
ALTER TABLE [dbo].[t_documento_resp]
ADD CONSTRAINT [FK_t_documento_resp_id]
    FOREIGN KEY ([id_documento])
    REFERENCES [dbo].[t_documento]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_t_documento_resp_id'
CREATE INDEX [IX_FK_t_documento_resp_id]
ON [dbo].[t_documento_resp]
    ([id_documento]);
GO

-- Creating foreign key on [id_usuario] in table 't_carpeta_estado'
ALTER TABLE [dbo].[t_carpeta_estado]
ADD CONSTRAINT [FK_t_carpeta_estado_p_usuario]
    FOREIGN KEY ([id_usuario])
    REFERENCES [dbo].[p_usuario]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_t_carpeta_estado_p_usuario'
CREATE INDEX [IX_FK_t_carpeta_estado_p_usuario]
ON [dbo].[t_carpeta_estado]
    ([id_usuario]);
GO

-- Creating foreign key on [idusr_control] in table 't_carpeta'
ALTER TABLE [dbo].[t_carpeta]
ADD CONSTRAINT [FK_t_carpeta_usr_control_FK]
    FOREIGN KEY ([idusr_control])
    REFERENCES [dbo].[p_usuario]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_t_carpeta_usr_control_FK'
CREATE INDEX [IX_FK_t_carpeta_usr_control_FK]
ON [dbo].[t_carpeta]
    ([idusr_control]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------