USE [Muebles]
GO
/****** Object:  Table [dbo].[Estados_Asignacion]    Script Date: 10/17/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estados_Asignacion](
	[id_estado] [int] NOT NULL,
	[descripcion] [varchar](20) NULL,
 CONSTRAINT [PK_Estados_Asignacion] PRIMARY KEY CLUSTERED 
(
	[id_estado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 10/17/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleados](
	[legajo] [int] NOT NULL,
	[dni] [numeric](18, 0) NOT NULL,
	[fecha_ingreso] [datetime] NOT NULL,
	[nombres] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[legajo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 10/17/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Permisos](
	[id_permiso] [int] NOT NULL,
	[Descripcion] [varchar](60) NULL,
 CONSTRAINT [PK_Permisos] PRIMARY KEY CLUSTERED 
(
	[id_permiso] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Unidades_Medida]    Script Date: 10/17/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Unidades_Medida](
	[id_ud_medida] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[abreviatura] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Unidades_Medida] PRIMARY KEY CLUSTERED 
(
	[id_ud_medida] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Unidades_Medida] ON [dbo].[Unidades_Medida] 
(
	[nombre] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipos_Mueble]    Script Date: 10/17/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipos_Mueble](
	[id_tipo_mueble] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Tipos_Mueble] PRIMARY KEY CLUSTERED 
(
	[id_tipo_mueble] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10/17/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[id_rol] [int] NOT NULL,
	[descripcion] [varchar](100) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 10/17/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[id_cliente] [int] NOT NULL,
	[nombres] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
	[telefono] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 10/17/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cargo](
	[id] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Cargo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 10/17/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id_usuario] [varchar](20) NOT NULL,
	[id_rol] [int] NULL,
	[hashed_password] [varchar](50) NULL,
	[id_cliente] [int] NULL,
	[legajo] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Materiales]    Script Date: 10/17/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Materiales](
	[id_material] [int] IDENTITY(1,1) NOT NULL,
	[denominacion] [varchar](20) NOT NULL,
	[caracteristicas] [varchar](50) NOT NULL,
	[stock_minimo] [decimal](18, 2) NOT NULL,
	[stock_real] [decimal](18, 2) NOT NULL,
	[stock_asignado] [decimal](18, 2) NULL,
	[id_ud_medida] [int] NOT NULL,
 CONSTRAINT [PK_Materiales] PRIMARY KEY CLUSTERED 
(
	[id_material] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Asignaciones_Produccion]    Script Date: 10/17/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignaciones_Produccion](
	[id_asignacion] [numeric](18, 0) NOT NULL,
	[fecha_hora] [datetime] NOT NULL,
	[duracion] [numeric](18, 0) NOT NULL,
	[legajo_ejecutor] [int] NOT NULL,
	[legajo_encargado_asignacion] [numeric](18, 0) NULL,
	[cantidad] [nchar](10) NULL,
	[estado] [int] NULL,
 CONSTRAINT [PK_Asignaciones_Trabajo] PRIMARY KEY CLUSTERED 
(
	[id_asignacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos_Rol]    Script Date: 10/17/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos_Rol](
	[id_permiso] [int] NOT NULL,
	[id_rol] [int] NOT NULL,
 CONSTRAINT [PK_Permisos_Rol] PRIMARY KEY CLUSTERED 
(
	[id_permiso] ASC,
	[id_rol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Permisos_Rol] ON [dbo].[Permisos_Rol] 
(
	[id_permiso] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos_produccion_muebles]    Script Date: 10/17/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos_produccion_muebles](
	[id_pedido_produccion] [numeric](18, 0) NOT NULL,
	[fecha_hora] [datetime] NOT NULL,
	[id_cliente] [int] NOT NULL,
	[legajo] [int] NOT NULL,
	[cant_tareas] [numeric](18, 0) NOT NULL,
	[monto_total] [money] NOT NULL,
 CONSTRAINT [PK_Pedidos_produccion_muebles] PRIMARY KEY CLUSTERED 
(
	[id_pedido_produccion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ordenes_Compra]    Script Date: 10/17/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ordenes_Compra](
	[id_orden_compra] [numeric](18, 0) NOT NULL,
	[fecha_hora] [datetime] NOT NULL,
	[monto_total] [numeric](18, 0) NOT NULL,
	[legajo_encargado_compra] [int] NOT NULL,
 CONSTRAINT [PK_Ordenes_Compra] PRIMARY KEY CLUSTERED 
(
	[id_orden_compra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Muebles]    Script Date: 10/17/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Muebles](
	[id_mueble] [numeric](18, 0) NOT NULL,
	[id_tipo_mueble] [int] NULL,
	[denominacion] [nchar](10) NOT NULL,
	[características] [nchar](10) NOT NULL,
	[costo] [money] NOT NULL,
	[precio_venta] [money] NOT NULL,
 CONSTRAINT [PK_Muebles] PRIMARY KEY CLUSTERED 
(
	[id_mueble] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materiales_Muebles]    Script Date: 10/17/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materiales_Muebles](
	[id_material] [int] NOT NULL,
	[id_mueble] [numeric](18, 0) NOT NULL,
	[cantidad] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Materiales_Muebles] PRIMARY KEY CLUSTERED 
(
	[id_material] ASC,
	[id_mueble] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalles_Pedido_Produccion]    Script Date: 10/17/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalles_Pedido_Produccion](
	[id_detalle_pedido_produccion] [numeric](18, 0) NOT NULL,
	[id_pedido_produccion] [numeric](18, 0) NOT NULL,
	[id_mueble] [numeric](18, 0) NOT NULL,
	[cantidad] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Detalles_Pedido_Produccion] PRIMARY KEY CLUSTERED 
(
	[id_detalle_pedido_produccion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalles_Orden_Compra]    Script Date: 10/17/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalles_Orden_Compra](
	[id_detalle_orden_compra] [numeric](18, 0) NOT NULL,
	[id_orden_compra] [numeric](18, 0) NOT NULL,
	[id_material] [int] NOT NULL,
	[precio_unitario] [nchar](10) NULL,
	[cantidad] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Detalles_Orden_Compra] PRIMARY KEY CLUSTERED 
(
	[id_detalle_orden_compra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Asignaciones_Produccion]    Script Date: 10/17/2013 22:23:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Asignaciones_Produccion](
	[id_asignacion] [numeric](18, 0) NOT NULL,
	[horas_estimadas] [nchar](10) NULL,
	[id_detalle_asignacion] [numeric](18, 0) NOT NULL,
	[id_detalle_pedido_prod] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Detalle_Asignaciones_Trabajo_1] PRIMARY KEY CLUSTERED 
(
	[id_detalle_asignacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Usuarios_Clientes]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Clientes] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Clientes] ([id_cliente])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Clientes]
GO
/****** Object:  ForeignKey [FK_Usuarios_Empleados]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Empleados] FOREIGN KEY([legajo])
REFERENCES [dbo].[Empleados] ([legajo])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Empleados]
GO
/****** Object:  ForeignKey [FK_Usuarios_Roles]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([id_rol])
REFERENCES [dbo].[Roles] ([id_rol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
/****** Object:  ForeignKey [FK_Materiales_Unidades_Medida]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Materiales]  WITH CHECK ADD  CONSTRAINT [FK_Materiales_Unidades_Medida] FOREIGN KEY([id_ud_medida])
REFERENCES [dbo].[Unidades_Medida] ([id_ud_medida])
GO
ALTER TABLE [dbo].[Materiales] CHECK CONSTRAINT [FK_Materiales_Unidades_Medida]
GO
/****** Object:  ForeignKey [FK_Asignaciones_Trabajo_Empleados]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Asignaciones_Produccion]  WITH CHECK ADD  CONSTRAINT [FK_Asignaciones_Trabajo_Empleados] FOREIGN KEY([legajo_ejecutor])
REFERENCES [dbo].[Empleados] ([legajo])
GO
ALTER TABLE [dbo].[Asignaciones_Produccion] CHECK CONSTRAINT [FK_Asignaciones_Trabajo_Empleados]
GO
/****** Object:  ForeignKey [FK_Asignaciones_Trabajo_Empleados1]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Asignaciones_Produccion]  WITH CHECK ADD  CONSTRAINT [FK_Asignaciones_Trabajo_Empleados1] FOREIGN KEY([legajo_ejecutor])
REFERENCES [dbo].[Empleados] ([legajo])
GO
ALTER TABLE [dbo].[Asignaciones_Produccion] CHECK CONSTRAINT [FK_Asignaciones_Trabajo_Empleados1]
GO
/****** Object:  ForeignKey [FK_Asignaciones_Trabajo_Estados_Asignacion]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Asignaciones_Produccion]  WITH CHECK ADD  CONSTRAINT [FK_Asignaciones_Trabajo_Estados_Asignacion] FOREIGN KEY([estado])
REFERENCES [dbo].[Estados_Asignacion] ([id_estado])
GO
ALTER TABLE [dbo].[Asignaciones_Produccion] CHECK CONSTRAINT [FK_Asignaciones_Trabajo_Estados_Asignacion]
GO
/****** Object:  ForeignKey [FK_Permisos_Rol_Permisos]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Permisos_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Permisos_Rol_Permisos] FOREIGN KEY([id_permiso])
REFERENCES [dbo].[Permisos] ([id_permiso])
GO
ALTER TABLE [dbo].[Permisos_Rol] CHECK CONSTRAINT [FK_Permisos_Rol_Permisos]
GO
/****** Object:  ForeignKey [FK_Permisos_Rol_Roles]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Permisos_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Permisos_Rol_Roles] FOREIGN KEY([id_rol])
REFERENCES [dbo].[Roles] ([id_rol])
GO
ALTER TABLE [dbo].[Permisos_Rol] CHECK CONSTRAINT [FK_Permisos_Rol_Roles]
GO
/****** Object:  ForeignKey [FK_Pedidos_produccion_muebles_Clientes]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Pedidos_produccion_muebles]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_produccion_muebles_Clientes] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Clientes] ([id_cliente])
GO
ALTER TABLE [dbo].[Pedidos_produccion_muebles] CHECK CONSTRAINT [FK_Pedidos_produccion_muebles_Clientes]
GO
/****** Object:  ForeignKey [FK_Pedidos_produccion_muebles_Empleados]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Pedidos_produccion_muebles]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_produccion_muebles_Empleados] FOREIGN KEY([legajo])
REFERENCES [dbo].[Empleados] ([legajo])
GO
ALTER TABLE [dbo].[Pedidos_produccion_muebles] CHECK CONSTRAINT [FK_Pedidos_produccion_muebles_Empleados]
GO
/****** Object:  ForeignKey [FK_Ordenes_Compra_Empleados]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Ordenes_Compra]  WITH CHECK ADD  CONSTRAINT [FK_Ordenes_Compra_Empleados] FOREIGN KEY([legajo_encargado_compra])
REFERENCES [dbo].[Empleados] ([legajo])
GO
ALTER TABLE [dbo].[Ordenes_Compra] CHECK CONSTRAINT [FK_Ordenes_Compra_Empleados]
GO
/****** Object:  ForeignKey [FK_Muebles_Tipos_Mueble]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Muebles]  WITH CHECK ADD  CONSTRAINT [FK_Muebles_Tipos_Mueble] FOREIGN KEY([id_tipo_mueble])
REFERENCES [dbo].[Tipos_Mueble] ([id_tipo_mueble])
GO
ALTER TABLE [dbo].[Muebles] CHECK CONSTRAINT [FK_Muebles_Tipos_Mueble]
GO
/****** Object:  ForeignKey [FK_Materiales_Muebles_Materiales]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Materiales_Muebles]  WITH CHECK ADD  CONSTRAINT [FK_Materiales_Muebles_Materiales] FOREIGN KEY([id_material])
REFERENCES [dbo].[Materiales] ([id_material])
GO
ALTER TABLE [dbo].[Materiales_Muebles] CHECK CONSTRAINT [FK_Materiales_Muebles_Materiales]
GO
/****** Object:  ForeignKey [FK_Materiales_Muebles_Muebles]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Materiales_Muebles]  WITH CHECK ADD  CONSTRAINT [FK_Materiales_Muebles_Muebles] FOREIGN KEY([id_mueble])
REFERENCES [dbo].[Muebles] ([id_mueble])
GO
ALTER TABLE [dbo].[Materiales_Muebles] CHECK CONSTRAINT [FK_Materiales_Muebles_Muebles]
GO
/****** Object:  ForeignKey [FK_Detalles_Pedido_Produccion_Muebles]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Detalles_Pedido_Produccion]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_Pedido_Produccion_Muebles] FOREIGN KEY([id_mueble])
REFERENCES [dbo].[Muebles] ([id_mueble])
GO
ALTER TABLE [dbo].[Detalles_Pedido_Produccion] CHECK CONSTRAINT [FK_Detalles_Pedido_Produccion_Muebles]
GO
/****** Object:  ForeignKey [FK_Detalles_Pedido_Produccion_Pedidos_produccion_muebles]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Detalles_Pedido_Produccion]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_Pedido_Produccion_Pedidos_produccion_muebles] FOREIGN KEY([id_pedido_produccion])
REFERENCES [dbo].[Pedidos_produccion_muebles] ([id_pedido_produccion])
GO
ALTER TABLE [dbo].[Detalles_Pedido_Produccion] CHECK CONSTRAINT [FK_Detalles_Pedido_Produccion_Pedidos_produccion_muebles]
GO
/****** Object:  ForeignKey [FK_Detalles_Orden_Compra_Materiales]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Detalles_Orden_Compra]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_Orden_Compra_Materiales] FOREIGN KEY([id_material])
REFERENCES [dbo].[Materiales] ([id_material])
GO
ALTER TABLE [dbo].[Detalles_Orden_Compra] CHECK CONSTRAINT [FK_Detalles_Orden_Compra_Materiales]
GO
/****** Object:  ForeignKey [FK_Detalles_Orden_Compra_Ordenes_Compra]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Detalles_Orden_Compra]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_Orden_Compra_Ordenes_Compra] FOREIGN KEY([id_orden_compra])
REFERENCES [dbo].[Ordenes_Compra] ([id_orden_compra])
GO
ALTER TABLE [dbo].[Detalles_Orden_Compra] CHECK CONSTRAINT [FK_Detalles_Orden_Compra_Ordenes_Compra]
GO
/****** Object:  ForeignKey [FK_Detalle_Asignaciones_Trabajo_Asignaciones_Trabajo]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Detalle_Asignaciones_Produccion]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Asignaciones_Trabajo_Asignaciones_Trabajo] FOREIGN KEY([id_asignacion])
REFERENCES [dbo].[Asignaciones_Produccion] ([id_asignacion])
GO
ALTER TABLE [dbo].[Detalle_Asignaciones_Produccion] CHECK CONSTRAINT [FK_Detalle_Asignaciones_Trabajo_Asignaciones_Trabajo]
GO
/****** Object:  ForeignKey [FK_Detalle_Asignaciones_Trabajo_Detalles_Pedido_Produccion]    Script Date: 10/17/2013 22:23:41 ******/
ALTER TABLE [dbo].[Detalle_Asignaciones_Produccion]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Asignaciones_Trabajo_Detalles_Pedido_Produccion] FOREIGN KEY([id_detalle_pedido_prod])
REFERENCES [dbo].[Detalles_Pedido_Produccion] ([id_detalle_pedido_produccion])
GO
ALTER TABLE [dbo].[Detalle_Asignaciones_Produccion] CHECK CONSTRAINT [FK_Detalle_Asignaciones_Trabajo_Detalles_Pedido_Produccion]
GO
