import { Component } from '@angular/core';

@Component({
    selector: 'navigation',
    template: './navigation.component.html',
})

export class NavigationComponent {
    isCollapsed: boolean = true;
}