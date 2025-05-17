SiteFunctions = {

    GeneratePieChart: function (piechartData) {        

        //It works, but I'm not too happy with this method
        const oldsvg = d3.select("#piechart");
        oldsvg.selectAll("*").remove();

        const width = 450;
        const height = 450;
        const radius = 200;

        const svg = d3.select("#piechart")
            .append("svg")
            .attr("width", width)
            .attr("height", height);        

        const g = svg.append('g')
            .attr("transform", `translate(${width / 2},${height / 2})`);

        const pie = d3.pie()
            .value(d => d.value);

        const path = d3.arc()
            .outerRadius(radius)
            .innerRadius(radius - 130);

        const label = d3.arc()
            .outerRadius(radius)
            .innerRadius(radius - 120);
            
        const arcs = g.selectAll('.arc')
            .data(pie(piechartData.records))
            .enter()
            .append('g')
            .classed('arc', true);
            
        arcs.append('path')
            .attr('d', d => path(d))
            .attr('fill', d => d.data.color);

        arcs.append('text')
            .text(d => d.data.browserName)
            .attr('text-anchor', 'middle')
            .attr('transform', d => `translate(${label.centroid(d)})`);
    }
}