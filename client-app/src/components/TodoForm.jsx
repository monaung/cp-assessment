import { useContext, useRef } from "react";

export default function TodoForm({ add }) {
	
	const titleRef = useRef();
	const noteRef = useRef();

	return (
		<form
			onSubmit={e => {
				e.preventDefault();
				const title = titleRef.current.value;
				const note = noteRef.current.value;

				add(title, note);

				e.currentTarget.reset();
			}}
			style={{
				display: "flex",
				flexDirection: "column",
				gap: 4,
				padding: 10,
				borderRadius: 8,
				marginBottom: 20,
				background: "#def",
			}}>
			<input
				ref={titleRef}
				type="text"
				placeholder="Task"
				style={{
					padding: 5,
					border: "0 none",
					outlineWidth: 0,
					borderRadius: 5,
					background: "#fff",
					color:  "black",
				}}
			/>
			<input
				ref={noteRef}
				type="text"
				placeholder="Note"
				style={{
					padding: 5,
					border: "0 none",
					outlineWidth: 0,
					borderRadius: 5,
					background: "#fff",
					color: "black",
				}}
			/>
			<button
				type="Submit"
				style={{
					padding: 8,
					background: "#0d6efd",
					color: "white",
					border: "0 none",
					borderRadius: 5,
				}}>
				Add
			</button>
		</form>
	);
}
