# NetCore 3.1 MVC Reusable ViewComponents

This repo is an attempt at demonstrating a framework that allows one to easily reuse various ViewComponents in a way that allows you to define 
the rendered HTML and the supporting javascript/CSS, and render each configuration once per given set of ComponentParameters.

This allows you to reuse components without fear of duplicating scripts and styles unnecessarily.

One of the bigger bonuses of this approach is that - despite components declaring their scripts/tyles in uniuqe .cshtml folders, users only have to declare their components in the HTML elements. 
The 'framework' registers the components in a shared ComponentContext which is responsible for later running and executing the scripts/tyles.

Each component is generated with an ID based on the property values of the parameters (think ValueObjects). 
Given a different set of properties, a new style will be applied for that component.
Scripts are generated once-per-component.

In the example present here, there are 4 present components. Since Components 1 & 2 have the same ID, they share one style script. They all share the same scripts section script as well.