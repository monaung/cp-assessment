import axios from 'axios';
import { useEffect, useState } from 'react'

function App() {
 
  const [todoItems, setTodoItems] = useState([]);

  useEffect(() => {

    axios.get("https://localhost:5001/api/todo")
      .then(response => {
        setTodoItems(response.data)
      })
  }, [])

  return (
    <div>
      <h1>Todo List</h1>
      <ul>
        {todoItems.map((todo: any) => (
          <li key={todo.id}>{todo.title}</li>
        ))}
      </ul>
    </div>
  )}

export default App
