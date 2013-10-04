USE [Muebles]
GO
/****** Object:  Table [dbo].[Muebles]    Script Date: 08/22/2013 01:25:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Muebles](
	[id_mueble] [numeric](18, 0) NOT NULL,
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
/****** Object:  Table [dbo].[Permisos]    Script Date: 08/22/2013 01:25:43 ******/
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
/****** Object:  Table [dbo].[Unidades_Medida]    Script Date: 08/22/2013 01:25:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unidades_Medida](
	[id_ud_medida] [numeric](18, 0) NOT NULL,
	[nombre] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Unidades_Medida] PRIMARY KEY CLUSTERED 
(
	[id_ud_medida] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 08/22/2013 01:25:43 ******/
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
/****** Object:  Table [dbo].[Usuarios]    Script Date: 08/22/2013 01:25:43 ******/
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
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Permisos_Rol]    Script Date: 08/22/2013 01:25:43 ******/
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
/****** Object:  Table [dbo].[Materiales]    Script Date: 08/22/2013 01:25:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materiales](
	[id_material] [numeric](18, 0) NOT NULL,
	[denominacion] [nchar](10) NOT NULL,
	[caracteristicas] [nchar](10) NOT NULL,
	[stock_minimo] [numeric](18, 0) NOT NULL,
	[stock_real] [numeric](18, 0) NOT NULL,
	[stock_asignado] [nchar](10) NULL,
	[id_ud_medida] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Materiales] PRIMARY KEY CLUSTERED 
(
	[id_material] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 08/22/2013 01:25:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleados](
	[legajo] [numeric](18, 0) NOT NULL,
	[dni] [numeric](18, 0) NOT NULL,
	[id_cargo] [numeric](18, 0) NOT NULL,
	[fecha_ingreso] [datetime] NOT NULL,
	[nombres] [nchar](10) NOT NULL,
	[id_usuario] [varchar](20) NULL,
	[apellidos] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[legajo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Materiales_Muebles]    Script Date: 08/22/2013 01:25:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materiales_Muebles](
	[id_material] [numeric](18, 0) NOT NULL,
	[id_mueble] [numeric](18, 0) NOT NULL,
	[cantidad] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Materiales_Muebles] PRIMARY KEY CLUSTERED 
(
	[id_material] ASC,
	[id_mueble] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 08/22/2013 01:25:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[id_cliente] [numeric](18, 0) NOT NULL,
	[nombres] [varchar](50) NOT NULL,
	[apellidos] [nchar](10) NOT NULL,
	[id_usuario] [varchar](20) NULL,
	[telefono] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pedidos_produccion_muebles]    Script Date: 08/22/2013 01:25:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos_produccion_muebles](
	[id_pedido_produccion] [numeric](18, 0) NOT NULL,
	[fecha_hora] [datetime] NOT NULL,
	[id_cliente] [numeric](18, 0) NOT NULL,
	[legajo] [numeric](18, 0) NOT NULL,
	[cant_tareas] [numeric](18, 0) NOT NULL,
	[monto_total] [money] NOT NULL,
 CONSTRAINT [PK_Pedidos_produccion_muebles] PRIMARY KEY CLUSTERED 
(
	[id_pedido_produccion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ordenes_Compra]    Script Date: 08/22/2013 01:25:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ordenes_Compra](
	[id_orden_compra] [numeric](18, 0) NOT NULL,
	[fecha_hora] [datetime] NOT NULL,
	[total_items] [numeric](18, 0) NOT NULL,
	[legajo] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Ordenes_Compra] PRIMARY KEY CLUSTERED 
(
	[id_orden_compra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asignaciones_Trabajo]    Script Date: 08/22/2013 01:25:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignaciones_Trabajo](
	[id_asignacion] [numeric](18, 0) NOT NULL,
	[fecha_hora] [datetime] NOT NULL,
	[duracion] [numeric](18, 0) NOT NULL,
	[legajo] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Asignaciones_Trabajo] PRIMARY KEY CLUSTERED 
(
	[id_asignacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalles_Pedido_Produccion]    Script Date: 08/22/2013 01:25:43 ******/
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
/****** Object:  Table [dbo].[Detalles_Orden_Compra]    Script Date: 08/22/2013 01:25:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalles_Orden_Compra](
	[id_detalle_orden_compra] [numeric](18, 0) NOT NULL,
	[id_orden_compra] [numeric](18, 0) NOT NULL,
	[id_material] [numeric](18, 0) NOT NULL,
	[cantidad] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Detalles_Orden_Compra] PRIMARY KEY CLUSTERED 
(
	[id_detalle_orden_compra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Asignaciones_Trabajo]    Script Date: 08/22/2013 01:25:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Asignaciones_Trabajo](
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
/****** Object:  ForeignKey [FK_Usuarios_Roles]    Script Date: 08/22/2013 01:25:43 ******/
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([id_rol])
REFERENCES [dbo].[Roles] ([id_rol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
/****** Object:  ForeignKey [FK_Permisos_Rol_Permisos]    Script Date: 08/22/2013 01:25:43 ******/
ALTER TABLE [dbo].[Permisos_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Permisos_Rol_Permisos] FOREIGN KEY([id_permiso])
REFERENCES [dbo].[Permisos] ([id_permiso])
GO
ALTER TABLE [dbo].[Permisos_Rol] CHECK CONSTRAINT [FK_Permisos_Rol_Permisos]
GO
/****** Object:  ForeignKey [FK_Permisos_Rol_Roles]    Script Date: 08/22/2013 01:25:43 ******/
ALTER TABLE [dbo].[Permisos_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Permisos_Rol_Roles] FOREIGN KEY([id_rol])
REFERENCES [dbo].[Roles] ([id_rol])
GO
ALTER TABLE [dbo].[Permisos_Rol] CHECK CONSTRAINT [FK_Permisos_Rol_Roles]
GO
/****** Object:  ForeignKey [FK_Materiales_Unidades_Medida]    Script Date: 08/22/2013 01:25:43 ******/
ALTER TABLE [dbo].[Materiales]  WITH CHECK ADD  CONSTRAINT [FK_Materiales_Unidades_Medida] FOREIGN KEY([id_ud_medida])
REFERENCES [dbo].[Unidades_Medida] ([id_ud_medida])
GO
ALTER TABLE [dbo].[Materiales] CHECK CONSTRAINT [FK_Materiales_Unidades_Medida]
GO
/****** Object:  ForeignKey [FK_Empleados_Usuarios]    Script Date: 08/22/2013 01:25:43 ******/
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_Usuarios]
GO
/****** Object:  ForeignKey [FK_Materiales_Muebles_Materiales]    Script Date: 08/22/2013 01:25:43 ******/
ALTER TABLE [dbo].[Materiales_Muebles]  WITH CHECK ADD  CONSTRAINT [FK_Materiales_Muebles_Materiales] FOREIGN KEY([id_material])
REFERENCES [dbo].[Materiales] ([id_material])
GO
ALTER TABLE [dbo].[Materiales_Muebles] CHECK CONSTRAINT [FK_Materiales_Muebles_Materiales]
GO
/****** Object:  ForeignKey [FK_Materiales_Muebles_Muebles]    Script Date: 08/22/2013 01:25:43 ******/
ALTER TABLE [dbo].[Materiales_Muebles]  WITH CHECK ADD  CONSTRAINT [FK_Materiales_Muebles_Muebles] FOREIGN KEY([id_mueble])
REFERENCES [dbo].[Muebles] ([id_mueble])
GO
ALTER TABLE [dbo].[Materiales_Muebles] CHECK CONSTRAINT [FK_Materiales_Muebles_Muebles]
GO
/****** Object:  ForeignKey [FK_Clientes_Usuarios]    Script Date: 08/22/2013 01:25:43 ******/
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Usuarios]
GO
/****** Object:  ForeignKey [FK_Pedidos_produccion_muebles_Clientes]    Script Date: 08/22/2013 01:25:43 ******/
ALTER TABLE [dbo].[Pedidos_produccion_muebles]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_produccion_muebles_Clientes] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Clientes] ([id_cliente])
GO
ALTER TABLE [dbo].[Pedidos_produccion_muebles] CHECK CONSTRAINT [FK_Pedidos_produccion_muebles_Clientes]
GO
/****** Object:  ForeignKey [FK_Pedidos_produccion_muebles_Empleados]    Script Date: 08/22/2013 01:25:43 ******/
ALTER TABLE [dbo].[Pedidos_produccion_muebles]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_produccion_muebles_Empleados] FOREIGN KEY([legajo])
REFERENCES [dbo].[Empleados] ([legajo])
GO
ALTER TABLE [dbo].[Pedidos_produccion_muebles] CHECK CONSTRAINT [FK_Pedidos_produccion_muebles_Empleados]
GO
/****** Object:  ForeignKey [FK_Ordenes_Compra_Empleados]    Script Date: 08/22/2013 01:25:43 ******/
ALTER TABLE [dbo].[Ordenes_Compra]  WITH CHECK ADD  CONSTRAINT [FK_Ordenes_Compra_Empleados] FOREIGN KEY([legajo])
REFERENCES [dbo].[Empleados] ([legajo])
GO
ALTER TABLE [dbo].[Ordenes_Compra] CHECK CONSTRAINT [FK_Ordenes_Compra_Empleados]
GO
/****** Object:  ForeignKey [FK_Asignaciones_Trabajo_Empleados]    Script Date: 08/22/2013 01:25:43 ******/
ALTER TABLE [dbo].[Asignaciones_Trabajo]  WITH CHECK ADD  CONSTRAINT [FK_Asignaciones_Trabajo_Empleados] FOREIGN KEY([legajo])
REFERENCES [dbo].[Empleados] ([legajo])
GO
ALTER TABLE [dbo].[Asignaciones_Trabajo] CHECK CONSTRAINT [FK_Asignaciones_Trabajo_Empleados]
GO
/****** Object:  ForeignKey [FK_Detalles_Pedido_Produccion_Muebles]    Script Date: 08/22/2013 01:25:43 ******/
ALTER TABLE [dbo].[Detalles_Pedido_Produccion]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_Pedido_Produccion_Muebles] FOREIGN KEY([id_mueble])
REFERENCES [dbo].[Muebles] ([id_mueble])
GO
ALTER TABLE [dbo].[Detalles_Pedido_Produccion] CHECK CONSTRAINT [FK_Detalles_Pedido_Produccion_Muebles]
GO
/****** Object:  ForeignKey [FK_Detalles_Pedido_Produccion_Pedidos_produccion_muebles]    Script Date: 08/22/2013 01:25:43 ******/
ALTER TABLE [dbo].[Detalles_Pedido_Produccion]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_Pedido_Produccion_Pedidos_produccion_muebles] FOREIGN KEY([id_pedido_produccion])
REFERENCES [dbo].[Pedidos_produccion_muebles] ([id_pedido_produccion])
GO
ALTER TABLE [dbo].[Detalles_Pedido_Produccion] CHECK CONSTRAINT [FK_Detalles_Pedido_Produccion_Pedidos_produccion_muebles]
GO
/****** Object:  ForeignKey [FK_Detalles_Orden_Compra_Materiales]    Script Date: 08/22/2013 01:25:43 ******/
ALTER TABLE [dbo].[Detalles_Orden_Compra]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_Orden_Compra_Materiales] FOREIGN KEY([id_material])
REFERENCES [dbo].[Materiales] ([id_material])
GO
ALTER TABLE [dbo].[Detalles_Orden_Compra] CHECK CONSTRAINT [FK_Detalles_Orden_Compra_Materiales]
GO
/****** Object:  ForeignKey [FK_Detalles_Orden_Compra_Ordenes_Compra]    Script Date: 08/22/2013 01:25:43 ******/
ALTER TABLE [dbo].[Detalles_Orden_Compra]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_Orden_Compra_Ordenes_Compra] FOREIGN KEY([id_orden_compra])
REFERENCES [dbo].[Ordenes_Compra] ([id_orden_compra])
GO
ALTER TABLE [dbo].[Detalles_Orden_Compra] CHECK CONSTRAINT [FK_Detalles_Orden_Compra_Ordenes_Compra]
GO
/****** Object:  ForeignKey [FK_Detalle_Asignaciones_Trabajo_Asignaciones_Trabajo]    Script Date: 08/22/2013 01:25:43 ******/
ALTER TABLE [dbo].[Detalle_Asignaciones_Trabajo]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Asignaciones_Trabajo_Asignaciones_Trabajo] FOREIGN KEY([id_asignacion])
REFERENCES [dbo].[Asignaciones_Trabajo] ([id_asignacion])
GO
ALTER TABLE [dbo].[Detalle_Asignaciones_Trabajo] CHECK CONSTRAINT [FK_Detalle_Asignaciones_Trabajo_Asignaciones_Trabajo]
GO
/****** Object:  ForeignKey [FK_Detalle_Asignaciones_Trabajo_Detalles_Pedido_Produccion]    Script Date: 08/22/2013 01:25:43 ******/
ALTER TABLE [dbo].[Detalle_Asignaciones_Trabajo]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Asignaciones_Trabajo_Detalles_Pedido_Produccion] FOREIGN KEY([id_detalle_pedido_prod])
REFERENCES [dbo].[Detalles_Pedido_Produccion] ([id_detalle_pedido_produccion])
GO
ALTER TABLE [dbo].[Detalle_Asignaciones_Trabajo] CHECK CONSTRAINT [FK_Detalle_Asignaciones_Trabajo_Detalles_Pedido_Produccion]
GO
