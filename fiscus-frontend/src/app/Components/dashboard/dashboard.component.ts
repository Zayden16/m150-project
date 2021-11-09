import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  chartOptions: any;
  costData: any;
  categoryData: any;
  constructor() { }

  ngOnInit(): void {
    this.chartOptions = {
      plugins: {
        legend: {
          labels: {
            color: '#ebedef'
          }
        }
      },
      scales: {
        x: {
          ticks: {
            color: '#ebedef'
          },
          grid: {
            color: 'rgba(255,255,255,0.2)'
          }
        },
        y: {
          ticks: {
            color: '#ebedef'
          },
          grid: {
            color: 'rgba(255,255,255,0.2)'
          }
        }
      }
    }
    this.costData = {
      labels: ["01.11.2021", "02.11.2021", "03.11.2021", "04.11.2021"],
      datasets: [{
        label: '$',
        fill: false,
        borderColor: '#42A5F5',
        yAxisID: 'y',
        tension: .4,
        data: [40, 60, 190, 220]
      }]
    }

    this.categoryData = {
      labels: ['👚','🛒','🍴', '🏥'],
            datasets: [
                {
                    data: [200, 550, 150, 1200],
                    backgroundColor: [
                        "#42A5F5",
                        "#66BB6A",
                        "#FFA726",
                        "#FF1940"
                    ],
                    hoverBackgroundColor: [
                        "#64B5F6",
                        "#81C784",
                        "#FFB74D",
                        "#FFA193"
                    ]
                }
            ]
    }
  }
}
