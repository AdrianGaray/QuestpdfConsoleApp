using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Previewer;


// code in your main method
Document.Create(document =>
{
    document.Page(page =>
    {
        /* page.Header().Height(100).Background(Colors.Blue.Medium);
        page.Content().Background(Colors.Yellow.Medium);
        page.Footer().Height(50).Background(Colors.Red.Medium); */

        page.Margin(30);

        page.Header().ShowOnce().Row(row =>
        {
            /* row.RelativeItem().Border(1).Background(Colors.Green.Medium).Height(100);
            row.RelativeItem().Border(1).Background(Colors.Red.Medium).Height(100);
            row.RelativeItem().Border(1).Background(Colors.Yellow.Medium).Height(100); */

            row.ConstantItem(140).Height(60).Placeholder();

            row.RelativeItem().Column(col =>
            {
                /* col.Item().Background(Colors.Orange.Medium).Height(10);
                col.Item().Background(Colors.Green.Medium).Height(10); */

                col.Item().AlignCenter().Text("Codigo Estudiante SAC").Bold().FontSize(14);
                col.Item().AlignCenter().Text("Jr. las mercedez N45-Lima").FontSize(9);
                col.Item().AlignCenter().Text("356 342 534534 /3345345").FontSize(9);
                col.Item().AlignCenter().Text("codigo@gmail.com").FontSize(9);
            });

            row.RelativeItem().Column(col =>
            {
                col.Item().Border(1).BorderColor("#257272").AlignCenter().Text("RUC21231234124").Bold();

                col.Item().Background("#257272").Border(1).BorderColor("#257272").AlignCenter().Text("Boleta de Venta").FontColor("#fff");

                col.Item().Border(1).BorderColor("#257272").AlignCenter().Text("B0001-234").Bold();
            });

        });

        page.Content().PaddingVertical(10).Column(col1 =>
        {
            col1.Item().Column(col2 =>
            {
                col2.Item().Text("Datos del cliente").Underline().Bold();

                col2.Item().Text(txt =>
                {
                    txt.Span("Nombre: ").SemiBold().FontSize(10);
                    txt.Span("Mario Mendoza").FontSize(10);
                });

                col2.Item().Text(txt =>
                {
                    txt.Span("DNI: ").SemiBold().FontSize(10);
                    txt.Span("1231231231").FontSize(10);
                });

                col2.Item().Text(txt =>
                {
                    txt.Span("Direccion: ").SemiBold().FontSize(10);
                    txt.Span("Gualeguaychu 2015").FontSize(10);
                });
            });


            // representa la linea horizontal
            col1.Item().LineHorizontal(0.5f);

            // tabala
            col1.Item().Table(tabla =>
            {
                // definicion de las columnas
                tabla.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(3);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                // cabecera de la tabla
                tabla.Header(header =>
                {
                    header.Cell().Background("#257272").Padding(2).Text("Producto").FontColor("#fff");
                    header.Cell().Background("#257272").Padding(2).Text("Precio Unit").FontColor("#fff");
                    header.Cell().Background("#257272").Padding(2).Text("Cantidad").FontColor("#fff");
                    header.Cell().Background("#257272").Padding(2).Text("Total").FontColor("#fff");
                });

                // Poblar la informacion de nuestra tabla
                foreach (var item in Enumerable.Range(1,45))
                {
                    var cantidad = Placeholders.Random.Next(1, 10);
                    var precio = Placeholders.Random.Next(5, 15);
                    var total = cantidad * precio;

                    // 1° columna
                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text(Placeholders.Label()).FontSize(10);
                
                    // 2° columna
                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text($"S/.{precio}").FontSize(10);
                
                    // 3° columna
                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).Text(cantidad.ToString()).FontSize(10);
                
                    // 4° columna
                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Padding(2).AlignRight().Text($"S/.{total}").FontSize(10);
                }

            });

            col1.Item().AlignRight().Text("Total: 1500").FontSize(12);

            col1.Item().Background(Colors.Grey.Lighten3).Padding(10).Column(column =>
            {
                column.Item().Text("Comentarios").FontSize(14);
                column.Item().Text(Placeholders.LoremIpsum());
                column.Spacing(5);
            });

            col1.Spacing(10);

        });

        page.Footer().AlignRight().Text(txt =>
        {
            txt.Span("Pagina ").FontSize(10);
            txt.CurrentPageNumber().FontSize(10);
            txt.Span(" De ").FontSize(10);
            txt.TotalPages().FontSize(10);
        });

    });
}).ShowInPreviewer();

