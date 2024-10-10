import * as React from 'react';

export default function TodoItem(prop) {

const todoItems = prop.todoItems;

  return (

		<ul
			style={{
				listStyle: "none",
				padding: 0,
				margin: 0,
				border: "1px solid #ddd",
				borderColor: "#ddd",
				borderRadius: 8,
				overflow: "hidden",
			}}>
         {todoItems.map((todoItem) => 
            <li key={todoItem.id} 
            style={{
              padding: 10,
              borderBottom: "1px solid #ddd",
              borderColor:  "#ddd",
              display: "flex",
              flexDirection: "row",
              justifyContent: "space-between",
            }}>
              <div>
                {todoItem.title}
              </div>
              <div>
                {todoItem.note}
              </div>
            <button onClick={() => remove(todoItem.id)}>Delete</button>
            </li>
            )}
		</ul>
	);
}
